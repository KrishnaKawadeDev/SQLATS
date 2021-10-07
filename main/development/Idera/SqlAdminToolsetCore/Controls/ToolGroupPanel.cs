using System ;
using System.Windows.Forms ;

namespace Idera.SqlAdminToolset.Core
{
	/// <summary>
	/// Summary description for NumericTextBox.
	/// </summary>
	public partial class ToolGroupPanel : DevComponents.DotNetBar.Controls.GroupPanel
	{
      public ToolGroupPanel()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Stylesheet 
         this.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.IsShadowEnabled     = true;
         this.BackColor           = System.Drawing.Color.Transparent;
      }
	}
}
