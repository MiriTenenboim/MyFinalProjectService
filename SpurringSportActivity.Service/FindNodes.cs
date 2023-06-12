using SpurringSportActivity.Repositories;
using SpurringSportActivity.Service.Interfaces;
using SpurringSportActivity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Service
{
    public class FindNodes : IFindNodes
    {
        public List<bool> visited;
        // אורך הרדיוס הרצוי
        public int numSteps;

        private readonly IBestRoute _bestRoute;
        private readonly IPublicPointService _publicPointService;

        public FindNodes(IBestRoute bestRoute, IPublicPointService publicPointService)
        {
            _bestRoute = bestRoute;
            _publicPointService = publicPointService;
        }

        // QuadTree פונקציה זו תופעל ברגע שהמשתמש מתחיל לצעוד וכל פעם שמגיע לאחד העלים של ה 
        public QuadTree OnLoad(int id, double x, double y)
        {
            // ?
            numSteps = _bestRoute.CalculateLength(id);
            if (numSteps == 0)
            {
                // אם הוא משתמש חדש
                // מספר הצעדים יהיה המספר הממוצע בעולם
                numSteps = 17000;
            }
            double vertex1, vertex2, vertex3, vertex4;
            // חישוב ארבעת הקודקודים של הריבוע שנוצר מסביב למיקום הנוכחי של המשתמש
            vertex1 = x - numSteps;
            vertex2 = x + numSteps;
            vertex3 = y - numSteps;
            vertex4 = y + numSteps;
            var area = new Area(vertex1, vertex2, vertex3, vertex4);
            // שליפת הנקודות שלא מומשו שנמצאות בריבוע מסביב למיקום הנוכחי של המשתמש
            var allNotRealizedPoints = _publicPointService.GetAllNotRealizedPoints(area).Result;
            // List<Node>המרת רשימת הנקודות ל 
            var countNodes = allNotRealizedPoints.Count;
            //var nodesArray = new int[countNodes];
            var nodes = new QuadTreeNode[countNodes];
            QuadTreeNode newNode;
            // שמור למיקום הנוכחי של המשתמש
            //nodesArray[0] = 0;
            for (int i = 0; i < countNodes; i++)
            {
                // המרת קוד הנקודה למיקום במערך
                //nodesArray[i] = allNotRealizedPoints[i - 1].PointId;
                var notRealizedPoint = allNotRealizedPoints[i].Point;
                newNode = new QuadTreeNode(i, notRealizedPoint.PointX, notRealizedPoint.PointY);
                nodes[i] = newNode;
            }
            // QuadTree המרת רשימת הצמתים ל 
            // QuadTree יצירת 
            var quadTree = new QuadTree(x, y, countNodes);
            for (int i = 0; i < countNodes; i++)
            {
                // QuadTree הוספת הצמתים ל 
                quadTree.Insert(nodes[i]);
            }
            return quadTree;
        }
    }
}