using System.Drawing;

namespace IderaTrialExperienceCommon.Controls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class WindowControls: UserControl
    {
        private bool maximize;
        private  int _top;
        private  int _left;
        private  int _width;
        private  int _height;
        private  FormWindowState _windowState;
        public WindowControls()
        {
            this.InitializeComponent();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.ParentForm.WindowState = FormWindowState.Minimized;
            this.ParentForm.Show();
        }

        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            ToggleFormSize();

        }


        public void ToggleFormSize()
        {
            if (this.Maximize)
            {
      
                if (this.ParentForm == null)
                {
                    return;
                }

                if (_windowState == FormWindowState.Maximized|| this.ParentForm.WindowState==FormWindowState.Maximized)
                {

                    RestoreNormalState();
                    this.ParentForm.Show();

                }
                else if (_windowState == FormWindowState.Normal)
                {
                    SaveWindowState();
                    Rectangle workingArea = Screen.GetWorkingArea(ParentForm);
                    
                    MaximizeWindow(workingArea);
                    this.ParentForm.Show();
                }
            }
        }

        private void MaximizeWindow(Rectangle workingArea)
        {
            this.ParentForm.Top = workingArea.Top;
            this.ParentForm.Left = workingArea.Left;

            this.ParentForm.Height = workingArea.Height;
            this.ParentForm.Width = workingArea.Width;
            _windowState = FormWindowState.Maximized;
            maximizeBtn.Image = Properties.Resources.Normalize;
            toolTip1.SetToolTip(maximizeBtn, "Restore Down");
        }

        private void RestoreNormalState()
        {
            ParentForm.WindowState=FormWindowState.Normal;
            this.ParentForm.Top = _top;
            this.ParentForm.Left = _left;

            this.ParentForm.Height = _height;
            this.ParentForm.Width = _width;
            _windowState = FormWindowState.Normal;
            maximizeBtn.Image = Properties.Resources.Maximize;
            toolTip1.SetToolTip(maximizeBtn, "Maximize");
        }

        private void SaveWindowState()
        {
            _top = ParentForm.Top;
            _left = ParentForm.Left;
            _width = ParentForm.Width;
            _height = ParentForm.Height;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        [Category("Appearance")]
        [Description("Gets or sets if button will be visible")]
        public bool Maximize
        {
            get
            {
                return this.maximizeBtn.Visible;
            }
            set
            {
                this.maximizeBtn.Visible = value;
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets if button will be visible")]
        public bool Minimize
        {
            get
            {
                return this.minimizeBtn.Visible;
            }
            set
            {
                this.minimizeBtn.Visible = value;
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets if button will be visible")]
        public bool Close
        {
            get
            {
                return this.closeBtn.Visible;
            }
            set
            {
                this.closeBtn.Visible = value;
            }
        }
    }
}
