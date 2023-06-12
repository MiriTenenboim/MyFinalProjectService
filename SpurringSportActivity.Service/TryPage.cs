using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Service
{
    public class TryPage
    {
        // FindNodes
        // שורה 29
        // מציאת כל המסלולים במעגל מסביב למיקום של הצועד
        // numSteps אורך הרדיוס הוא
        // Quadtree שמירת הנקודות תהיה ב
        //public void DFS(List<List<Node>> graph, Node node, double currentLength)
        //{
        //    if (currentLength <= numSteps)
        //    {
        //        // Quadtree לפני ההוספה ל
        //        // Envelope מחייב להוסיף 
        //        // ? מה זה
        //        // Create an Envelope for the node
        //        //Envelope envelope = new Envelope(
        //        //new Coordinate(node.Latitude, node.Longitude)
        //        //new Coordinate(node.Latitude, node.Longitude)
        //        //);

        //        // Quadtree הוספה ל
        //        //nodesQuadtree.Insert(envelope, node);
        //    }
        //    if (currentLength == numSteps)
        //    {
        //        return;
        //    }
        //    visited[node.NodeId] = true;
        //    foreach (var edge in graph[node.NodeId])
        //    {
        //        Node nextNode = edge;
        //        double edgeLength = edge.Length;
        //        if (!visited[nextNode.NodeId] && currentLength + edgeLength <= numSteps)
        //        {
        //            DFS(graph, nextNode, currentLength + edgeLength);
        //        }
        //    }
        //    visited[node.NodeId] = false;
        //}

        // שורה 91
        // מיותר או נצרך ?
        //Node newNode1 = null, newNode2 = null;
        // הוספת קשת בין הצומת הנוכחית שנוספה לבין כל שאר צמתי הגרף
        //for (int j = i + 1; j < countNodes; j++)
        //{
        //    if (allNotRealizedPoints[j].Point.UserOrCompany == EStatus.User)
        //    {
        //        // להחליף את ה 0 במה שיחזור מפונקצית המרחק של מפות גוגל
        //        newNode1 = new Node(i, j, 0, allNotRealizedPoints[j].Point.User.CouponAmount, allNotRealizedPoints[i].Point.PointX, allNotRealizedPoints[i].Point.PointY);
        //        newNode2 = new Node(j, i, 0, allNotRealizedPoints[j].Point.User.CouponAmount, allNotRealizedPoints[j].Point.PointX, allNotRealizedPoints[j].Point.PointY);
        //    }
        //    else
        //    {
        //        // להחליף את ה 0 במה שיחזור מפונקצית המרחק של מפות גוגל
        //        newNode1 = new Node(i, j, 0, allNotRealizedPoints[j].Point.Company.Coupon.CouponDetail, allNotRealizedPoints[i].Point.PointX, allNotRealizedPoints[i].Point.PointY);
        //        newNode2 = new Node(j, i, 0, allNotRealizedPoints[j].Point.Company.Coupon.CouponDetail, allNotRealizedPoints[j].Point.PointX, allNotRealizedPoints[j].Point.PointY);
        //    }
        //}
        //nodes.Append(newNode1);
        //nodes.Append(newNode2);

        // DFS - בצורה הזאת נראה שאפשר לוותר על החיפוש 
        // var graph = _bestRoute.CreateGraph(allNotRealizedPoints);
        //DFS(מה שמתקבל מהפונקציה , 0);
        //while (true)
        //{
        // אם המרחק בין המיקום הנוכחי של המשתטמש לבין הנקודה שממנה מצאנו את כל הנקודות
        // שווה למרחק שנחליט - לרדיוס נמצא שוב את כל הנקודות מסביב
        // DFS(קודקוד אמצע המעגל שהיה עד עכשיו , 0)
        //}

        // דוגמא לגרף
        //graph = new List<List<Node>>();
        //visited = new List<bool>();
        //for (int i = 0; i < 7; i++)
        //{
        //    graph.Add(new List<Node>());
        //    visited.Add(false);
        //}
        //var a1 = new Node(0, 1, 1, 1);
        //var a2 = new Node(1, 0, 1, 1);
        //var a3 = new Node(0, 3, 1, 1);
        //var a4 = new Node(3, 0, 1, 1);
        //var a5 = new Node(1, 2, 2, 1);
        //var a6 = new Node(2, 1, 2, 1);
        //var a7 = new Node(1, 4, 4, 6);
        //var a8 = new Node(4, 1, 4, 6);
        //var a9 = new Node(2, 6, 5, 1);
        //var a10 = new Node(6, 2, 5, 1);
        //var a11 = new Node(3, 5, 8, 1);
        //var a12 = new Node(5, 3, 8, 1);
        //var a13 = new Node(3, 4, 4, 6);
        //var a14 = new Node(4, 3, 4, 6);
        //var a15 = new Node(4, 6, 6, 1);
        //var a16 = new Node(6, 4, 6, 1);
        //var a17 = new Node(5, 6, 9, 1);
        //var a18 = new Node(6, 5, 9, 1);
        //graph[0].Add(a1);
        //graph[1].Add(a2);
        //graph[0].Add(a3);
        //graph[3].Add(a4);
        //graph[1].Add(a5);
        //graph[2].Add(a6);
        //graph[1].Add(a7);
        //graph[4].Add(a8);
        //graph[2].Add(a9);
        //graph[6].Add(a10);
        //graph[3].Add(a11);
        //graph[5].Add(a12);
        //graph[3].Add(a13);
        //graph[4].Add(a14);
        //graph[4].Add(a15);
        //graph[6].Add(a16);
        //graph[5].Add(a17);
        //graph[6].Add(a18);
    }
}
