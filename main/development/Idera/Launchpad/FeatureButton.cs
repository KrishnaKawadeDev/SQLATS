using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Launchpad
{
    [ToolboxItem(true)]
    public partial class FeatureButton : UserControl
    {
        private FeatureButtonState state = FeatureButtonState.Normal;
        private Image _originalImage=null;

        private enum FeatureButtonState
        {
            Normal,
            MouseOver,
            Clicked
        }

        public FeatureButton()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            
            InitializeComponent();
        }

       protected override void OnLoad( EventArgs e )
       {
          base.OnLoad( e );
         
          if ( ! Enabled )
          {
             _originalImage = featureImagePictureBox.Image;
             Bitmap b = new Bitmap( featureImagePictureBox.Image );
             greyscale( b, featureImagePictureBox );
          }
       }

        [Category("Appearance")]
        public string HeaderText
        {
            get { return featureHeaderLabel.Text; }
            set { featureHeaderLabel.Text = value; }
        }

        [Category("Appearance")]
        public Color HeaderColor
        {
            get { return featureHeaderLabel.ForeColor; }
            set { featureHeaderLabel.ForeColor = value; }
        }

        [Category("Appearance")]
        public string DescriptionText
        {
            get { return featureDescriptionLabel.Text; }
            set { featureDescriptionLabel.Text = value; }
        }

        [Category("Appearance")]
        public Image Image
        {
            get { return featureImagePictureBox.Image; }
            set { featureImagePictureBox.Image = value; }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            foreach (Control control in Controls)
            {
                control.Enabled = Enabled;

                if (!Enabled)
                {
                    Bitmap b = new Bitmap(featureImagePictureBox.Image);
                    greyscale(b, featureImagePictureBox);
                }
                else
                {
                    if (_originalImage != null)
                        Image = _originalImage;
                }
            }

            base.OnEnabledChanged(e);
        }
        
        /*Insert this as a function anywere, I used it in a seperate DLL to keep my form code clean.  Just pass the Bitmap and the picture box to show it in to the function*/
        private void greyscale(Bitmap bmp, PictureBox picBox)
        {
            if (_originalImage == null) _originalImage = (Image) bmp.Clone();
            int r=0,g=0,b=0;
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* imgPtr = (byte*)(data.Scan0);
                byte red, green, blue;
                for (int i = 0; i < data.Height; i++)
                {
                    for (int j = 0; j < data.Width; j++)
                    {
                        blue = imgPtr[0];
                        green = imgPtr[1];
                        red = imgPtr[2];

                        imgPtr[0] = imgPtr[1] = imgPtr[2] = 
                           (byte)(.299 * red
                            + .587 * green
                            + .114 * blue);
                            
                        if ( i==0 && j==0 )
                        {
                           b = imgPtr[0];
                           g = imgPtr[1];
                           r = imgPtr[2];
                        }    
                            
                        imgPtr += 3;
                    }
                    imgPtr += data.Stride - data.Width * 3;
                }

            }
            bmp.UnlockBits(data);
            
            Color c = Color.FromArgb(r,g,b);            
            bmp.MakeTransparent( c );
            
            picBox.Image = bmp;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            state = FeatureButtonState.MouseOver;
            Invalidate(false);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            state = FeatureButtonState.Clicked;
            Invalidate(false);
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            state = FeatureButtonState.Normal;
            Invalidate(false);
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (state != FeatureButtonState.MouseOver)
            {
                state = FeatureButtonState.MouseOver;
                Invalidate(false);
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            state = FeatureButtonState.Normal;
            Invalidate(false);
            base.OnMouseLeave(e);
        }

        private void ChildControl_MouseEnter(object sender, EventArgs e)
        {
            state = FeatureButtonState.MouseOver;
            Invalidate(false);
        }

        private void ChildControl_MouseDown(object sender, MouseEventArgs e)
        {
            state = FeatureButtonState.Clicked;
            Invalidate(false);
        }

        private void ChildControl_MouseUp(object sender, MouseEventArgs e)
        {
            state = FeatureButtonState.Normal;
            Invalidate(false);
        }

        private void ChildControl_MouseLeave(object sender, EventArgs e)
        {
            state = FeatureButtonState.Normal;
            Invalidate(false);
        }

        private void ChildControl_MouseClick(object sender, MouseEventArgs e)
        {
           base.OnMouseClick(e);
        }

        private void ChildControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (state != FeatureButtonState.MouseOver)
            {
                state = FeatureButtonState.MouseOver;
                Invalidate(false);
            }
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            switch (state)
            {
                case FeatureButtonState.MouseOver:
                    DrawMouseOver(e.Graphics);
                    break;
                case FeatureButtonState.Clicked:
                    DrawClicked(e.Graphics);
                    break;
            }
        }

        private void DrawMouseOver(Graphics graphics)
        {
            if (graphics != null)
            {
                using (Pen pen = new Pen(Color.FromArgb(156, 223, 255)))
                {
                    Rectangle bounds = Rectangle.Inflate(ClientRectangle, -1, -1);
                    //DrawRoundRectangle(graphics, pen, Color.FromArgb(247, 255, 255), Color.FromArgb(214, 243, 255),
                    //                   bounds, 5);
                    DrawRoundRectangle(graphics, pen, Color.FromArgb(255, 218, 88), Color.FromArgb(255, 255, 255),
                                       bounds, 5);
                }
            }
        }

        private void DrawClicked(Graphics graphics)
        {
            if (graphics != null)
            {
                using (Pen pen = new Pen(Color.FromArgb(181, 231, 255)))
                {
                    Rectangle bounds = Rectangle.Inflate(ClientRectangle, -1, -1);
                    DrawRoundRectangle(graphics, pen, Color.FromArgb(239, 247, 255), Color.FromArgb(198, 235, 255),
                                       bounds, 5);
                }
            }
        }

        private void DrawRoundRectangle(Graphics graphics, Pen pen, Color fillColor1, Color fillColor2,
                                        RectangleF bounds, float radius)
        {
            if (graphics != null)
            {
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddLine(radius, 0, bounds.Width - (radius*2), 0);
                    gp.AddArc(bounds.Width - (radius*2), 0, radius*2, radius*2, 270, 90);
                    gp.AddLine(bounds.Width, radius, bounds.Width, bounds.Height - (radius*2));
                    gp.AddArc(bounds.Width - (radius*2), bounds.Height - (radius*2), radius*2, radius*2, 0, 90);
                    gp.AddLine(bounds.Width - (radius*2), bounds.Height, radius, bounds.Height);
                    gp.AddArc(0, bounds.Height - (radius*2), radius*2, radius*2, 90, 90);
                    gp.AddLine(0, bounds.Height - (radius*2), 0, radius);
                    gp.AddArc(0, 0, radius*2, radius*2, 180, 90);
                    gp.CloseFigure();

                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(ClientRectangle, fillColor1,
                                                                                   fillColor2,
                                                                                   LinearGradientMode.Vertical))
                    {
                        graphics.FillPath(fillBrush, gp);
                    }

                    graphics.DrawPath(pen, gp);
                }
            }
        }
    }
}