using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;

namespace Main1
{
    class ImgProc
    {
        /*
         * Load Image and Convert to bitmap
         *      Loads image from directory with given input name
         *      Takes image with given name and converts image to bitmap 
         *      Return bitmapped image
         *      
         *      
         *  Plot Temperature Data 
         *      Create blank image same size as schematic
         *      Grab data from LUT given location tag from the sensor 
         *      Grab Temp data from linked list 
         *      Plot Temp Data at Given pixel location
         *      Return New image with temp data plotted
         *      
         *  WE DONT NEED TO OVERLAY WE JUST NEED TO WRITE TEXT TO PICTURE. I AM SO STUPID
         * 
         *  GUI might be a really good idea so that they can visually see the new mapped image immediately vs. having to open new file
         * 
         * 
         *
         */
        private string StrBitmapPath;
        private Bitmap currentBitmap;
        private Bitmap bitmapBeforeProcessing;
       
        public ImgProc()    {   }
        public Bitmap CurrentBitmap
        {
            get
            {
                if (currentBitmap == null)
                    currentBitmap = new Bitmap(1, 1);
                return currentBitmap;
            }
            set { currentBitmap = value; }
        }

        public Bitmap BitmapBeforeProcessing
        {
            get { return bitmapBeforeProcessing; }
            set { bitmapBeforeProcessing = value; }
        }

        public string BitmapPath
        {
            get { return StrBitmapPath; }
            set { StrBitmapPath = value; }
        }

        public void ResetBitmap()
        {
            if(currentBitmap != null && bitmapBeforeProcessing != null)
            {
                Bitmap temp = (Bitmap)currentBitmap.Clone();
                currentBitmap = (Bitmap)bitmapBeforeProcessing.Clone();
                bitmapBeforeProcessing = (Bitmap)temp.Clone();
            }
        }

        public void SaveBitmap(string saveFilePath)
        {
            StrBitmapPath = saveFilePath;
            if (System.IO.File.Exists(saveFilePath))
                System.IO.File.Delete(saveFilePath);
            currentBitmap.Save(saveFilePath);
        }

        public void ClearImage()
        {
            currentBitmap = new Bitmap(1, 1);
        }

        public void RestorePrevious()
        {
            bitmapBeforeProcessing = currentBitmap;
        }

        //Continue more with Altan
        //Use Draw.Line function in order to make Crosses for temp data
        public void Resize(int newWidth, int newHeight)
        {
            if (newWidth != 0 && newHeight != 0)
            {
                Bitmap temp = (Bitmap)currentBitmap;
                Bitmap bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

                double nWidthFactor = (double)temp.Width / (double)newWidth;
                double nHeightFactor = (double)temp.Height / (double)newHeight;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                Color color1 = new Color();
                Color color2 = new Color();
                Color color3 = new Color();
                Color color4 = new Color();
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (int x = 0; x < bmap.Width; ++x)
                {
                    for (int y = 0; y < bmap.Height; ++y)
                    {

                        fr_x = (int)Math.Floor(x * nWidthFactor);
                        fr_y = (int)Math.Floor(y * nHeightFactor);
                        cx = fr_x + 1;
                        if (cx >= temp.Width) cx = fr_x;
                        cy = fr_y + 1;
                        if (cy >= temp.Height) cy = fr_y;
                        fx = x * nWidthFactor - fr_x;
                        fy = y * nHeightFactor - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        color1 = temp.GetPixel(fr_x, fr_y);
                        color2 = temp.GetPixel(cx, fr_y);
                        color3 = temp.GetPixel(fr_x, cy);
                        color4 = temp.GetPixel(cx, cy);

                        // Blue
                        bp1 = (byte)(nx * color1.B + fx * color2.B);

                        bp2 = (byte)(nx * color3.B + fx * color4.B);

                        nBlue = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Green
                        bp1 = (byte)(nx * color1.G + fx * color2.G);

                        bp2 = (byte)(nx * color3.G + fx * color4.G);

                        nGreen = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Red
                        bp1 = (byte)(nx * color1.R + fx * color2.R);

                        bp2 = (byte)(nx * color3.R + fx * color4.R);

                        nRed = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        bmap.SetPixel(x, y, System.Drawing.Color.FromArgb(255, nRed, nGreen, nBlue));
                    }
                }
                currentBitmap = (Bitmap)bmap.Clone();
            }
        }

        public void InsertText(string text, int xPosition, int yPosition, string fontName, float fontSize, string fontStyle, string colorName1, string colorName2)
        {
            Bitmap temp = (Bitmap)currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            if (string.IsNullOrEmpty(fontName))
                fontName = "Times New Roman";
            if (fontSize.Equals(null))
                fontSize = 10.0F;
            Font font = new Font(fontName, fontSize);
            if (!string.IsNullOrEmpty(fontStyle))
            {
                FontStyle fStyle = FontStyle.Regular;
                switch (fontStyle.ToLower())
                {
                    case "bold":
                        fStyle = FontStyle.Bold;
                        break;
                    case "italic":
                        fStyle = FontStyle.Italic;
                        break;
                    case "underline":
                        fStyle = FontStyle.Underline;
                        break;
                    case "strikeout":
                        fStyle = FontStyle.Strikeout;
                        break;

                }
                font = new Font(fontName, fontSize, fStyle);
            }
            if (string.IsNullOrEmpty(colorName1))
                colorName1 = "Black";
            if (string.IsNullOrEmpty(colorName2))
                colorName2 = colorName1;
            Color color1 = Color.FromName(colorName1);
            Color color2 = Color.FromName(colorName2);
            int gW = (int)(text.Length * fontSize);
            gW = gW == 0 ? 10 : gW;
            LinearGradientBrush LGBrush = new LinearGradientBrush(new Rectangle(0, 0, gW, (int)fontSize), color1, color2, LinearGradientMode.Vertical);
            gr.DrawString(text, font, LGBrush, xPosition, yPosition);
            currentBitmap = (Bitmap)bmap.Clone();
        }

        public void DrawLine(Point P1, Point P2, int width, string colourName)
        {
            Bitmap temp = (Bitmap)currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            if (string.IsNullOrEmpty(colourName))
                colourName = "Black";
            Pen pen = new Pen(Color.FromName(colourName),(float)width);

            gr.DrawLine(pen, P1, P2);

            currentBitmap = (Bitmap)bmap.Clone();
        }
    }
}
