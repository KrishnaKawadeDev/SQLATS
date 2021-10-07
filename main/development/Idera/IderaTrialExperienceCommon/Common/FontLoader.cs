using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace IderaTrialExperienceCommon.Common
{
   public class FontLoader
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private static PrivateFontCollection fonts = new PrivateFontCollection();

       public static Font LoadFont()
       {
           return LoadFont(8.5f);
       }
        public static Font LoadFont(float size)
        {
            Font loadedFont = null;
            try
            {
                if (fonts.Families.Length <= 0)
                {
                    byte[] fontData = Properties.Resources.Montserrat_Regular;
                    IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
                    System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                    uint dummy = 0;
                    fonts.AddMemoryFont(fontPtr, Properties.Resources.Montserrat_Regular.Length);
                    AddFontMemResourceEx(fontPtr, (uint) Properties.Resources.Montserrat_Regular.Length, IntPtr.Zero,
                        ref dummy);
                    System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
                }
                loadedFont = new Font(fonts.Families[0], size);
            }
            catch (Exception e)
            {
                loadedFont = new Font(FontFamily.GenericSansSerif, 8.5f);
            }
            return loadedFont;
        }

       public static void ApplyFont (Control control )
       {
           try
           {
               var resFont = LoadFont(control.Font.Size);
               if (resFont != null) control.Font = resFont;
           }
           catch
           {
               // ignored
           }
       }
    }
}
