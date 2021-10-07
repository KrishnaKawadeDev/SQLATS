using System;

namespace Idera.SqlAdminToolset.Core
{
    //------------------------------------------------------------------------------------------------------
    // MRU Class - class for managing most recently used list of servers/server groups for server selection
    //
    // we store this stuff encrypted in the registry since it includes password for credentials
    //------------------------------------------------------------------------------------------------------
    public class MRU
    {
        //------------------------------------------------------------------------
        // AddServerOrGroup
        //------------------------------------------------------------------------
        public static void AddServerOrGroup(bool isServer, string name, SQLCredentials credentials)
        {
            ToolsetOptions.ReadOptions();

            if (isServer)
            {
                ToolsetOptions.mruLastSelectionType = 0;
                AddServer(name, credentials);
            }
            else
            {
                ToolsetOptions.mruLastSelectionType = 1;
                AddGroup(name);
            }

            ToolsetOptions.WriteOptions();
        }

        //------------------------------------------------------------------------
        // AddServer
        //------------------------------------------------------------------------
        public static void AddServer(string server, SQLCredentials credentials)
        {
            AddItem(ref ToolsetOptions.mruServerCount,
                     ref ToolsetOptions.mruServers,
                     ref ToolsetOptions.mruServerCredentials,
                     server,
                     credentials);
        }

        //------------------------------------------------------------------------
        // AddGroup
        //------------------------------------------------------------------------
        public static void AddGroup(string group)
        {
            SQLCredentials[] fake = null;

            AddItem(ref ToolsetOptions.mruGroupCount,
                     ref ToolsetOptions.mruGroups,
                     ref fake,
                     group,
                     null);
        }

        //------------------------------------------------------------------------
        // AddItem
        //------------------------------------------------------------------------
        private static void AddItem(
              ref int listCount,
              ref string[] list,
              ref SQLCredentials[] credList,
              string name,
              SQLCredentials credentials
           )
        {
            // hard logic only exists if we already have list items
            if (listCount != 0)
            {
                int i;

                // determine if item is already in list
                int pos = -1;
                for (i = 0; i < listCount; i++)
                {
                    if (list[i] == name)
                    {
                        pos = i;
                        break;
                    }
                }

                // if its already the first item in the list - make sure credentials are correct and then we are done
                if (pos == 0)
                {
                    if (credList != null)
                    {
                        credList[0] = credentials;
                    }
                    return;
                }

                // adjust list size appropriately - if not in list, list will grow by one unless we are at max
                if (pos == -1)
                {
                    listCount = Math.Min(listCount + 1, ToolsetOptions.mruMax);

                    for (i = listCount - 1; i > 0; i--)
                    {
                        list[i] = list[i - 1];
                        if (credList != null) credList[i] = credList[i - 1];
                    }
                }
                else
                {
                    // already in list - move to front
                    for (i = pos; i > 0; i--)
                    {
                        list[i] = list[i - 1];
                        if (credList != null) credList[i] = credList[i - 1];
                    }
                }
            }
            else
            {
                listCount = 1;
            }

            // put new item at top of list
            list[0] = name;
            if (credList != null) credList[0] = credentials;
        }

        //------------------------------------------------------------------------
        // EncryptServer
        //------------------------------------------------------------------------
        static public string EncryptServer(int mruIndex)
        {
            return EncryptItem(ToolsetOptions.mruServers[mruIndex],
                                ToolsetOptions.mruServerCredentials[mruIndex]);
        }

        //------------------------------------------------------------------------
        // EncryptGroup
        //------------------------------------------------------------------------
        static public string EncryptGroup(int mruIndex)
        {
            return EncryptItem(ToolsetOptions.mruGroups[mruIndex], null);
        }

        //------------------------------------------------------------------------
        // EncryptItem
        //------------------------------------------------------------------------
        static public string EncryptItem(string name, SQLCredentials credentials)
        {
            string mruItem;

            if (credentials != null)// && credentials.useSqlAuthentication)
            {
                mruItem = String.Format("{0}\r{1}\r{2}\r{3}",
                                           name,
                                           credentials.loginName,
                                           credentials.password,credentials.useSqlAuthentication);
            }
            else
            {
                mruItem = name;
            }

            return EncryptionHelper.QuickEncrypt(mruItem);
        }

        //------------------------------------------------------------------------
        // DecryptGroup
        //------------------------------------------------------------------------
        static public string DecryptGroup(string savedMruItem)
        {
            return EncryptionHelper.QuickDecrypt(savedMruItem);
        }

        //------------------------------------------------------------------------
        // DecryptServer
        //------------------------------------------------------------------------
        static public void DecryptServer(string savedMruItem, out string name, out SQLCredentials credentials)
        {
            credentials = null;

            string decryptedMruItem = EncryptionHelper.QuickDecrypt(savedMruItem);

            string[] tokens = decryptedMruItem.Split('\r');

            name = tokens[0];

            if (tokens.Length == 4)
            {
                credentials = new SQLCredentials(Convert.ToBoolean(tokens[3]), tokens[1], tokens[2]);
            }
            else if (tokens.Length == 3)
            {
                credentials = new SQLCredentials(true, tokens[1], tokens[2]);

            }
            return;
        }
    }
}
