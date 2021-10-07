using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Idera.SqlAdminToolset.QuickReindex
{
    public class Table : DTIRecord
    {
        private List<Index> indexes;

        public List<Index> Indexes
        {
            get { return indexes; }
        }
     
       
        public int NumberIndexes
        {
            get { return indexes.Count; }
        }

        public int NumberCriticalIndexes
        {
            get
            {
                int count = 0;
                foreach (Index i in indexes)
                {
                    if (!i.IsFiltered && i.AverageFragLevel >= 75.0) 
                        count++;
                }
                return count;
            }            
        }
        public int NumberCautionIndexes
        {
            get
            {
                int count = 0;
                foreach (Index i in indexes)
                {
                    if (!i.IsFiltered && i.AverageFragLevel > 25.0 && i.AverageFragLevel < 75.0)
                        count++;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes
        {
            get
            {
                int count = 0;
                foreach (Index i in indexes)
                {
                    if (!i.IsFiltered && i.AverageFragLevel <= 25.0)
                        count++;
                }
                return count;
            }
        }

        public Table()
        {
            indexes = new List<Index>();    
        }
    }
}
