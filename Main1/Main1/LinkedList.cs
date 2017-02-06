using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Main1
{
    class LinkedList
    {

        private Node NodeHead; // Empty node at the start


        public void AddNodeToFront(int TagID,
                                   ulong LocTag,
                                   ulong TempData)
        {
            Node NodeToAdd = new Node();
            NodeToAdd.SetID(TagID);
            NodeToAdd.SetLocTag(LocTag);
            NodeToAdd.SetTemp(TempData);
            NodeHead = NodeToAdd;
        }


        public void AddNodeToBack(int TagID,
                                  ulong LocTag,
                                  ulong TempData)
        {

            if(NodeHead == null) // Handles an Empty List
            {
                NodeHead = new Node(TagID,LocTag,TempData);

                NodeHead.NodeNext = null;
            }
            else
            {

                Node NodeToAdd = new Node(TagID, LocTag, TempData);

                Node Current = NodeHead;
                while(Current.NodeNext != null)
                {
                    Current = Current.NodeNext;

                }

                Current.NodeNext = NodeToAdd;
            }



        }

        public void RemoveNode(int TagID) // To Be Continued
        {
            if(TagID == 0)
                {
                    Console.WriteLine("Tag ID to be Deleted is Null");
                    return;
                }

            Node NodeCurrent = NodeHead;
            Node NodePrev = NodeHead;

            while(NodeCurrent.NodeNext != null)
            {
                if (NodeCurrent.GetID() == TagID)
                {
                    NodePrev.NodeNext = NodeCurrent.NodeNext;
                    NodeCurrent.NodeNext = null;
                    break;
                }
                else
                {
                    NodePrev = NodePrev.NodeNext;
                    NodeCurrent = NodeCurrent.NodeNext;
                    
                }

            } 
        }

        public void EditTemp_Node(int TagID, ulong TempData)
        {
            if (TagID == 0)
            {
                Console.WriteLine("Argument \"TagID\" to Method EditTemp_Node is Null ");
            }
            Node Current = NodeHead;

        public void EditTemp_Node(int TagID, ulong TempData)
        {

            if (TagID == 0 || TempData == 0)
            {
                Console.WriteLine("Argument \"TempData\" or \"TagID\" to Method EditTag_Node is Null ");
            }
            Node Current = NodeHead;

            while (Current.NodeNext != null)
            {
                if (Current.GetID() == TagID)
                {
                    Current.SetTemp(TempData);
                }
            }




        }

        public void EditXYCoords_Node(int TagID, uint xCoord, uint yCoord)
        {

            if (xCoord == 0 || yCoord == 0)
            {
                Console.WriteLine("Argument \"xCoord\" or \"yCoord\" to Method EditXYCoords_Node is Null ");
            }

            Node Current = NodeHead;

            while (Current.NodeNext != null)
            {
                if (Current.GetID() == TagID)
                {
                    Current.SetXCoord(xCoord);
                    Current.SetYCoord(yCoord);
                }
            }


        }

        public void EditTag_Node(int OldTagID, int NewTagID)
        {

            if(OldTagID == 0 || NewTagID == 0)
                {
                Console.WriteLine("Argument \"OldTagID\" or \"NewTagID\" to Method EditTag_Node is Null "); 
                }
            Node Current = NodeHead;

            while(Current.NodeNext != null)
            {
                if(Current.GetID() == OldTagID)
                {
                    Current.SetID(NewTagID);
                }
            }


        }

        public void PrintAll_Nodes()
        {
            Node NodeCurrent = NodeHead;
            while (NodeCurrent != null)
            {
                Console.WriteLine("Node ID {0} has a Temperature Value of {1}",
                                    NodeCurrent.GetID(),
                                    NodeCurrent.GetTemp());

                NodeCurrent = NodeCurrent.NodeNext;
            }
        }


        public class Node
        {

//-----------VariableDeclaration---------------

            public Node NodeNext;
            private int u16TagID;
            private ulong u32LocTag;
            private ulong u32TempData;
            private uint u16xCoord;
            private uint u16yCoord;

//-----------EndVariableDeclaration---------------






//-----------Constructors---------------
            public Node() // Default Constructor
            {
                NodeNext = null;
                u16TagID = 0;
                u32LocTag = 0;
                u32TempData = 0;
                u16xCoord = 0;
                u16yCoord = 0;
            }

            public Node(int TagID, ulong LocTag, ulong TempData) // Constructor with Location Tag and TempData
            {
                NodeNext = null;
                u32LocTag = LocTag;
                u32TempData = TempData;
                u16TagID = TagID;
                u16xCoord = 0;
                u16yCoord = 0;
            }
//-----------EndConstructors---------------






//----------- SET FUNCTIONS ---------------
            public void SetID(int NewID)
            {
                if(NewID == 0)
                {
                    Console.WriteLine("Input argument to SetID for ID: {0} is Null", NewID);
                }
            }

            public void SetTemp( ulong NewTemperature)
            {
                if(NewTemperature == 0)
                {
                    Console.WriteLine("Input Argument to SetTemp for ID: {0} is Zero", this.GetID());
                }
                this.u32TempData = NewTemperature;
            }

            public void SetLocTag(ulong NewLoc)
            {
                if (NewLoc == 0)
                {
                    Console.WriteLine("New LocTag being added to ID: {0} is Zero", this.GetID());
                }
                this.u32LocTag = NewLoc;
            }

            public void SetXCoord(uint Xin)
            {
                if (Xin == 0)
                {
                    Console.WriteLine("New XLocation being added to ID: {0} is Zero", this.GetID());
                }
                this.u16xCoord = Xin;
            }

            public void SetYCoord(uint Yin)
            {
                if (Yin == 0)
                {
                    Console.WriteLine("New YLocation being added to ID: {0} is Zero", this.GetID());
                }
                this.u16xCoord = Yin;
            }


            //----------- END  SET FUNCTIONS ---------------





            //----------- GET FUNCTIONS ---------------
            public ulong GetTemp()
            {
                return this.u32TempData;
            }

            public ulong GetLoc()
            {
                return this.u32LocTag;
            }

            public int GetID()
            {
                return this.u16TagID;
            }

            public uint GeXCoord()
            {
                return this.u16xCoord;
                
            }

            public uint GetYCoord()
            {
                return this.u16yCoord;

            }
            //----------- END GET FUNCTIONS ---------------


        } // Close Class Node

    } // Close Class Linked List

}
