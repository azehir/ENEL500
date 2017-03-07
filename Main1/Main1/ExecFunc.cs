using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using static Main1.LinkedList;

namespace Main1
{
    class ExecFunc : Form
    {
        private ImgProc ImageProcessing  = new ImgProc();
        private LinkedList Lst = new LinkedList();
        private BluetoothComms Comms;
        private String FileFromRP;

        private void UpdateList(object sender, EventArgs e)
        {
            //Do we really need this funciton if everytime we generate a new image it updates the list?
            //What are we grabbing from the UI?
        }

        private void GenerateImage(object sender, PaintEventArgs e)
        {
            string sTagID;
            string sXPosition;
            string sYPosition;
            Point P1 = new Point();
            Point P2 = new Point();

            ImageProcessing.CurrentBitmap = (Bitmap)Bitmap.FromFile(/*Filepath name*/"TEMP");
            ImageProcessing.BitmapPath = "TEMP"; //Filepath

            Lst.UpdateList("TEMP Path");

            var fileStream = new FileStream("TEMP Path", FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(fileStream, Encoding.UTF8);

            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                sTagID = line.Substring(line.IndexOf("Tag:") + 5, 16);
                sXPosition = line.Substring(line.IndexOf("XPosition:") + 11, 32);
                sYPosition = line.Substring(line.IndexOf("YPosition:") + 11, 32);

                Lst.EditXYCoords_Node(Convert.ToUInt16(sTagID), Convert.ToUInt16(sXPosition), Convert.ToUInt16(sYPosition));
            }

            Node CurrentNode = Lst.nodeHead;
            while(CurrentNode != null)
            {
                P1.X = (int)CurrentNode.GeXCoord()-6; //6 Value can be changed arbitrary for now
                P1.Y = (int)CurrentNode.GetYCoord()-6;

                P2.X = (int)CurrentNode.GeXCoord()+6;
                P2.Y = (int)CurrentNode.GetYCoord()+6;

                ImageProcessing.DrawLine(P1, P2, 1, null);

                P1.X = (int)CurrentNode.GeXCoord() + 6; //6 Value can be changed arbitrary for now
                P1.Y = (int)CurrentNode.GetYCoord() - 6;

                P2.X = (int)CurrentNode.GeXCoord() - 6;
                P2.Y = (int)CurrentNode.GetYCoord() + 6;

                ImageProcessing.DrawLine(P1, P2, 1, null);

                ImageProcessing.InsertText((CurrentNode.GetTemp()).ToString(), (int)CurrentNode.GeXCoord() + 6, (int)CurrentNode.GetYCoord(), null, 0, null, null, null); //Can change peramteters to change colour and style

                CurrentNode = CurrentNode.NodeNext;
            }
            Graphics g = e.Graphics;
            g.DrawImage(ImageProcessing.CurrentBitmap, new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y, Convert.ToInt32(ImageProcessing.CurrentBitmap.Width), Convert.ToInt32(ImageProcessing.CurrentBitmap.Height)));



        }

        private void Bluetooth(object sender, EventArgs e)
        {

        }
        //public static void ThreadProc()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine("ThreadProc: {0}", i);
        //        // Yield the rest of the time slice.
        //        Thread.Sleep(0);
        //    }
        //}

            /*
             * ExecFunc will be used to execute all of the ui buttons to generate functionality
             * 
             * Bluetooth Button executes:
             *      
             * 
             * 
             */


        static void Main()
        {


            //Main will be used for the main window where it creates all the objects for each button press to run.
           
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
