using System ;
using System.Windows.Forms ;

namespace Idera.SqlAdminToolset.Core
{
	/// <summary>
	/// Summary description for NumericTextBox.
	/// </summary>
	public partial class NumericTextBox : DevComponents.DotNetBar.Controls.TextBoxX
	{
      public int NumericValue
      {
         get
         {
            int val = 0;

            try
            {
               if ( this.Text.Trim().Length == 0 )
                  val = 0;
               else
                  val = System.Convert.ToInt32( this.Text );
            }
            catch 
            {
               val = 0;
            }
            return val;
         }
      }

		public NumericTextBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

      protected override void OnKeyPress(KeyPressEventArgs e)
      {
         if (!Char.IsDigit(e.KeyChar) && e.KeyChar !=(char)8)
         {
            e.Handled=true; // input is not passed on to the control(TextBox) 
         }
         base.OnKeyPress (e);
      }
	}
}
