using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace Main1
{
    class ExecFunc
    {
        






        
        //public static void ThreadProc()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine("ThreadProc: {0}", i);
        //        // Yield the rest of the time slice.
        //        Thread.Sleep(0);
        //    }
        //}
        






        static void Main()
        {
            using (var src = new Bitmap("c:/temp/trans.png"))
            using (var bmp = new Bitmap(100, 100, PixelFormat.Format32bppPArgb))
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.Clear(Color.Black);
                gr.DrawImage(src, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save("c:/temp/result.png", ImageFormat.Png);
            }
            //Bitmap image1 = new Bitmap("C:/Users/Laptop/Source/Repos/ENEL500/Main1/Back View Transformer Schematic.png");
            //Bitmap image2 = new Bitmap("C:/Users/Laptop/Source/Repos/ENEL500/Main1/Side View Transformer Schematic.png");
            //var bmp = new Bitmap(image1.Width, image1.Height, PixelFormat.Format32bppPArgb);
            //var gr = Graphics.FromImage(image1);
            //gr.Clear(Color.White);
            //gr.DrawImage(image1, new Rectangle(0, 0, bmp.Width, bmp.Height));
            //bmp.Save("C:/temp/result.png", ImageFormat.Png);
            //Console.WriteLine("Main thread: Start a second thread.");
            //// The constructor for the Thread class requires a ThreadStart 
            //// delegate that represents the method to be executed on the 
            //// thread.  C# simplifies the creation of this delegate.
            //Thread t = new Thread(new ThreadStart(ThreadProc));

            //// Start ThreadProc
            //t.Start();
            ////Thread.Sleep(1);

            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine("Main thread: Do some work.");
            //    Thread.Sleep(0);
            //}

            //Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
            //t.Join();
            //Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
            //Console.ReadLine();






        } // Close Main()


    } // Close ExecFunc

    


} // Close NameSpace
