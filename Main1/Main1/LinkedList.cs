using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main1
{
    class LinkedList
    {
        public class Node
        {
            public Node NodeNext;
            private ulong u32LocTag;
            private ulong u32TempData;
            private uint u16xCoord;
            private uint u16yCoord;

            public Node()
            {
                NodeNext = null;
                u32LocTag = 0;
                u32TempData = 0;
                u16xCoord = 0;
                u16yCoord = 0;
            }
            public Node(ulong LocTag, ulong TempData)
            {
                NodeNext = null;
                u32LocTag = LocTag;
                u32TempData = TempData;
                u16xCoord = 0;
                u16yCoord = 0;
            }

            public void AddNode ()
            {

            }

            public void RemoveNode(ulong TagID)
            {

            }

            public void EditTemp_Node(ulong TagID, ulong TempData)
            {

            }

            public void EditXYCoords_Node(int xCoord, int yCoord)
            {

            }

            public void EditTag_Node(ulong TagID)
            {

            }
        }

    }

}
