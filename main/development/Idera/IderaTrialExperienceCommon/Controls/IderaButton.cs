using IderaTrialExperienceCommon.Common;

namespace IderaTrialExperienceCommon.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class IderaButton : UserControl
    {
        private bool isActive;

        public event EventHandler ButtonClick;

        public IderaButton()
        {
            this.InitializeComponent();
            this.ActiveButtonColor = System.Drawing.Color.FromArgb(255, 149, 201, 66);
            this.InActiveButtonColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            if (!DesignMode)
            {
                FontLoader.ApplyFont(btnText);
            }
        }


        public ContentAlignment ButtonTextAlign
        {
            get { return btnText.TextAlign; }
            set { btnText.TextAlign = value; }
        }
        [Category("Appearance")]
        [Description("Gets or sets button text")]
        public string ButtonText
        {
            get
            {
                return this.btnText.Text;
            }

            set
            {
                this.btnText.Text=value;
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets color of button text when button is active")]
        public Color ActiveButtonColor { get; set; }

        [Category("Appearance")]
        [Description("Gets or sets color of button text when button is inactive")]
        public Color InActiveButtonColor { get; set; }

        [Category("Appearance")]
        [Description("Gets or sets if button is active")]
        public bool Active
        {
            get
            {
                return this.isActive;
            }

            set
            {
                this.isActive = value;
                this.ActiveArrow.Visible = value;
                this.btnText.ForeColor = value ? this.ActiveButtonColor : this.InActiveButtonColor;
            }
        }

        protected virtual void OnButtonClick(EventArgs e)
        {
            var handler = this.ButtonClick;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        private void btnText_Click(object sender, EventArgs e)
        {
            this.OnButtonClick(e);
        }

        private void ActiveArrow_Click(object sender, EventArgs e)
        {
            this.OnButtonClick(e);
        }
    }
}
