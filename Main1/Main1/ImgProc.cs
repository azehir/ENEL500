using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;

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






    }

}
