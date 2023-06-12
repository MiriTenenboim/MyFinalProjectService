using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Service
{
    public class QuadTree
    {
        private QuadTreeNode root;
        public int numNodes { get; set; }

        public QuadTree(double x, double y, int numNodes)
        {
            // שורש העץ = המיקום הנוכחי של המשתמש
            root = new QuadTreeNode(0, x, y);
            this.numNodes = numNodes;
        }

        public void Insert(QuadTreeNode node)
        {
            InsertNode(node, root);
        }

        private void InsertNode(QuadTreeNode node, QuadTreeNode parent)
        {
            if (node.X <= parent.X && node.Y <= parent.Y)
            {
                if (parent.Child1 == null)
                {
                    parent.Child1 = node;
                }
                else
                {
                    InsertNode(node, parent.Child1);
                }
            }
            else if (node.X > parent.X && node.Y <= parent.Y)
            {
                if (parent.Child2 == null)
                {
                    parent.Child2 = node;
                }
                else
                {
                    InsertNode(node, parent.Child2);
                }
            }
            else if (node.X <= parent.X && node.Y > parent.Y)
            {
                if (parent.Child3 == null)
                {
                    parent.Child3 = node;
                }
                else
                {
                    InsertNode(node, parent.Child3);
                }
            }
            else
            {
                if (parent.Child4 == null)
                {
                    parent.Child4 = node;
                }
                else
                {
                    InsertNode(node, parent.Child4);
                }
            }
        }

        public QuadTreeNode FindClosestNode(double x, double y)
        {
            return FindClosestNode(x, y, root, double.MaxValue, null);
        }

        private QuadTreeNode FindClosestNode(double x, double y, QuadTreeNode node, double distance, QuadTreeNode closest)
        {
            if (node == null)
            {
                return closest;
            }

            double currentDistance = Math.Sqrt(Math.Pow(x - node.X, 2) + Math.Pow(y - node.Y, 2));
            if (currentDistance < distance)
            {
                distance = currentDistance;
                closest = node;
            }

            if (node.Child1 != null && node.X - distance <= x && node.Y - distance <= y)
            {
                closest = FindClosestNode(x, y, node.Child1, distance, closest);
            }
            if (node.Child2 != null && node.X + distance >= x && node.Y - distance <= y)
            {
                closest = FindClosestNode(x, y, node.Child2, distance, closest);
            }
            if (node.Child3 != null && node.X - distance <= x && node.Y + distance >= y)
            {
                closest = FindClosestNode(x, y, node.Child3, distance, closest);
            }
            if (node.Child4 != null && node.X + distance >= x && node.Y + distance >= y)
            {
                closest = FindClosestNode(x, y, node.Child4, distance, closest);
            }
            return closest;
        }
    }
}
