using System.Runtime.InteropServices;
using IderaTrialExperienceCommon.Common;

namespace IderaTrialExperienceCommon.Controls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
 
    public class IderaTrialProgress:ProgressBar
    {
       
        private Color lowColor;

        private Color midColor;

        private Color highColor;

        private string expText;
        public IderaTrialProgress()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.EnableNotifyMessage, true);
            this.LowColor = System.Drawing.Color.FromArgb(((int) (((byte) (149)))), ((int) (((byte) (201)))), ((int) (((byte) (66)))));
            this.MidColor = Color.Yellow;
            this.HighColor = Color.Red;
            this.ExpiredText = @"Expired";
            
        }

        private int Rate
        {
            get
            {
                var rate = 100 - (int)Math.Round(((float)this.RateValue / this.Maximum) * 100);
                return rate;
            } 
        }

        public float RateValue { get; set; }

        public Color LowColor
        {
            get
            {
                return this.lowColor;
            }
            set
            {
                this.lowColor = value;
            }
        }

        public Color MidColor
        {
            get
            {
                return this.midColor;
            }
            set
            {
                this.midColor = value;
            }
        }

        public Color HighColor
        {
            get
            {
                return this.highColor;
            }
            set
            {
                this.highColor = value;
            }
        }

        public string ExpiredText
        {
            get
            {
                return this.expText;
            }

            set
            {
                this.expText = value;
            }
        }

        private Color CurrentColor { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
           // base.OnPaint(e);
            Cursor.Current = Cursors.Default;

            Rectangle rec = this.ClientRectangle;
            RateValue = Value;
            if (this.Rate == 100)
            {
                rec.Width = (int)(rec.Width * (100d / this.Maximum));
            } //set bar absolutely red if expired
            else rec.Width = (int)(rec.Width * ((double)this.Value / this.Maximum));


            rec.Height = rec.Height;
            if (this.Rate >= 0 && this.Rate < 50)
            {
                this.CurrentColor = this.LowColor;
            }else if (this.Rate >= 50 && this.Rate < 78)
            {
                this.CurrentColor = this.MidColor;
            }
            else
            {
                this.CurrentColor = this.HighColor;
            }
            e.Graphics.FillRectangle(new SolidBrush(this.CurrentColor), 0, 0, rec.Width, rec.Height);
            if(this.Rate==100)
                using (Font f = FontLoader.LoadFont(10))
                {
                    SizeF len = e.Graphics.MeasureString(this.ExpiredText, f);
                    // Calculate the location of the text (the middle of progress bar)
                    
                    Point location = new Point(Convert.ToInt32((this.Width / 2) - len.Width / 2), Convert.ToInt32((this.Height / 2) - len.Height / 2));
                    // The commented-out code will centre the text into the highlighted area only. This will centre the text regardless of the highlighted area.
                    // Draw the custom text
                    e.Graphics.DrawString(this.ExpiredText, f, Brushes.White, location);
                }
        }

       
    }
}
