using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.WhoHasAccess
{
   public partial class Form_AccessDetails : Form
   {
      List<AccessDetails> _AccessDetails = new List<AccessDetails>();

      public Form_AccessDetails(List<AccessDetails> accessDetails, AccessDetailsRelation relation)
      {
         InitializeComponent();
         _AccessDetails = accessDetails;
         bool _ShowObjectAccess = false;

         if (_AccessDetails.Count > 0)
         {
            foreach (AccessDetails _Access in accessDetails)
            {
               _ShowObjectAccess = (_Access is ObjectAccessDetails);
            }
         }

         if (_ShowObjectAccess)
         {
            foreach (ObjectAccessDetails details in _AccessDetails)
            {
               string _Permission = string.Format("{0} - {1}", details.Action, details.Type);
               if (!string.IsNullOrEmpty(details.Column) && details.Column != ".")
               {
                  _Permission += string.Format(", Columns: {0}", details.Column);
               }
               ListViewItem _Item = new ListViewItem(_Permission);
               listDetails.Items.Add(_Item);
            }
         }
         else
         {
            foreach (AccessDetails details in _AccessDetails)
            {
               listDetails.Items.Add(details.Name);
            }
         }

         switch (relation)
         {
            case AccessDetailsRelation.MemberOf:
               listDetails.Columns[0].Text = "Member Of";
               break;
            case AccessDetailsRelation.AccessTo:
               listDetails.Columns[0].Text = "Access To";
               break;
            case AccessDetailsRelation.AccessibleBy:
               listDetails.Columns[0].Text = "Accessible By";
               break;
         }
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}