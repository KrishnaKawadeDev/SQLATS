using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Idera.SqlAdminToolset.Core
{
   public class GenericMru
   {
        private int _capacity;
        public int Capacity
        {
           get { return _capacity; }
           set
           {
              if ( value <=0 || value >= 1000 )
                 throw new Exception("Size of MRU must be between 0 1n 1000");
                 
              _capacity = value;
              
              // can shrink list easily so just waste memory until next time MRU is created
              if ( _capacity > Items.Capacity )  
              {
                 Items.Capacity = _capacity;
                 Tags.Capacity  = _capacity;
              }
           }
        }
        
        public int Count
        {
           get { return _count; }
        }
        
        private int          _count;
        public  List<string> Items;
        public  List<object> Tags;
        
        public GenericMru()
        {
           _capacity = 5;
           _count    = 0;
           Items    = new List<string>(5);
           Tags     = new List<object>(5);
        }

        public GenericMru( int capacity )
        {
           if ( capacity <=0 || capacity >= 1000 )
              throw new Exception("Size of MRU must be between 0 1n 1000");
              
           _capacity = capacity;
           _count    = 0;
           Items    = new List<string>(_capacity);
           Tags     = new List<object>(_capacity);
        }
        
        //------------------------------------------------------------------------
        // Clear
        //------------------------------------------------------------------------
        public void Clear()
        {
           Items.Clear();
        }
        
        //------------------------------------------------------------------------
        // AddItem
        //------------------------------------------------------------------------
        public void
           AddItem(
              string newItem
           )
        {
           AddItem( newItem, null );
        }
        
        //------------------------------------------------------------------------
        // AddItem
        //------------------------------------------------------------------------
        public void
           AddItem(
              string newItem,
              object itemTag
              
           )
        {
            // hard logic only exists if we already have some list items
            if (Items.Count > 0)
            {
                int i;

                // determine if item is already in list
                int pos = -1;
                for (i = 0; i < _count; i++)
                {
                    if (Items[i] == newItem)
                    {
                        pos = i;
                        break;
                    }
                }

                // if its already the first item in the list - make sure tag is correct and then we are done
                if (pos == 0)
                {
                    Tags[0] = itemTag;
                    return;
                }

                // adjust list size appropriately - if not in list, list will grow by one unless we are at max
                if (pos == -1)
                {
                    _count = Math.Min(_count + 1, _capacity);
                    if ( _count > Items.Count )
                    {
                       Items.Add( "" );
                       Tags.Add(null);
                    }

                    for (i = _count - 1; i > 0; i--)
                    {
                        Items[i] = Items[i - 1];
                        Tags[i]  = Tags[i- 1];
                    }
                }
                else
                {
                    // already in list - move to front
                    for (i = pos; i > 0; i--)
                    {
                        Items[i] = Items[i - 1];
                        Tags[i]  = Tags[i- 1];
                    }
                }
            }
            else
            {
                Items.Add( "" );
                Tags.Add(null);
                _count = 1;
            }

            // put new item at top of list
            Items[0] = newItem;
            Tags[0]  = itemTag;
        }
        
        public void
           Write(
              string       baseValueName,
              bool         writeTagsOnly
           )
        {
           // get registry key
           RegistryKey toolsetKey = null;
           RegistryKey optionsKey = null;
           
           try
           {
              toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
              optionsKey = toolsetKey.CreateSubKey(CoreGlobals.shortProductName);
              
              optionsKey.SetValue( baseValueName, _count);
              for ( int i=0; i<_count; i++)
              {
                 if ( !writeTagsOnly )
                 {
                    string valueName = String.Format( "{0}{1}", baseValueName, i );
                    optionsKey.SetValue( valueName, Items[i]);
                 }
                 
                 string tagValueName = String.Format( "{0}{1}_t", baseValueName, i );
                 optionsKey.SetValue( tagValueName, Tags[i].ToString());
              }
           }
           catch ( Exception ex )
           {
              CoreGlobals.traceLog.ErrorFormat("Error writing MRU List to registry", ex.Message );
           }
           finally
           {
              if ( toolsetKey != null ) toolsetKey.Close();
              if ( optionsKey != null ) optionsKey.Close();
           }
          
        }
        
        public void
           Read(
              string baseValueName
           )
        {
           // get registry key
           RegistryKey toolsetKey = null;
           RegistryKey optionsKey = null;
           
           try
           {
              toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
              optionsKey = toolsetKey.CreateSubKey(CoreGlobals.shortProductName);
              
              _count = 0;
              
              int regCount = (int)optionsKey.GetValue(baseValueName, 5);
              if ( regCount > this._capacity ) regCount = this._capacity;
              
              for ( int i=0; i<regCount; i++)
              {
                 string valueName    = String.Format( "{0}{1}",   baseValueName, i );
                 string tagValueName = String.Format( "{0}{1}_t", baseValueName, i );
                 
                 try
                 {
                    string item = (string)optionsKey.GetValue(valueName, "");
                    object tag  = optionsKey.GetValue(tagValueName, null);
                    
                    if ( item == "" && tag != null ) item = i.ToString();  // placeholder item value for people who write tags only and change later
                    
                    if ( item != "" )   // no item, no tag -- no add
                    {
                       AddItem( item, tag );
                    }
                 }
                 catch {}
              }
           }
           catch ( Exception ex )
           {
              CoreGlobals.traceLog.ErrorFormat("Error writing MRU List to registry", ex.Message );
           }
           finally
           {
              if ( toolsetKey != null ) toolsetKey.Close();
              if ( optionsKey != null ) optionsKey.Close();
           }
        }
    }
}
