using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Service
{
    public class QuadTreeNode
    {
        public int QuadTreeNodeId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public QuadTreeNode Child1 { get; set; }
        public QuadTreeNode Child2 { get; set; }
        public QuadTreeNode Child3 { get; set; }
        public QuadTreeNode Child4 { get; set; }

        public QuadTreeNode(int quadTreeNodeId,double x, double y)
        {
            QuadTreeNodeId = quadTreeNodeId;
            X = x;
            Y = y;
        }
    }
}
