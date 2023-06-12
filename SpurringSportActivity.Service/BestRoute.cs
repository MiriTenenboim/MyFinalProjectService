using Microsoft.Extensions.Configuration;
using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories;
using SpurringSportActivity.Service.Interfaces;
using SpurringSportActivity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Service
{
    public class BestRoute : IBestRoute
    {
        public List<Node>[] graph;
        public bool[] visited;
        public int length;
        public Node source;
        public List<List<Node>> routes = new List<List<Node>>();
        public List<Node> currentRoute = new List<Node>();
        public double closestLength = double.MaxValue;
        public List<List<Node>> closestRoutes = new List<List<Node>>();
        public Node nextNode;
        public int[] nodesArray;

        private readonly IPublicPointService _publicPointService;
        private readonly ISportActivitiesService _sportActivityService;
        private readonly IConfiguration _configuration;

        public BestRoute(IPublicPointService publicPointService, ISportActivitiesService sportActivityService, IConfiguration configuration)
        {
            _publicPointService = publicPointService;
            _sportActivityService = sportActivityService;
            _configuration = configuration;
        }

        // חישוב אורך המסלול שמגיע למשתמש לצעוד
        public int CalculateLength(int id)
        {
            var allSportActivities = _sportActivityService.GetSportActivitiesByIdAsync(id).Result;
            var count = allSportActivities.Count;
            float totalSteps = 0;
            for (int i = 0; i < count; i++)
            {
                totalSteps += allSportActivities[i].TotalSteps;
            }
            if (totalSteps == 0)
            {
                return 0;
            }
            return (int)(totalSteps / count);
        }

        // יצירת גרף מכל הנקודות שנמצאות באזור שאותו המשתמש בחר
        public void CreateGraph(List<PublicPointDTO> nodes)
        {
            var api = new GoogleMapsAPI(_configuration["GoogleMapAPI"]);
            // נעבור על כל הנקודות שהתקבלו ונוסיף כל נקודה כצומת בגרף
            // נוסיף גם קשת מכל צומת לכל שאר הצמתים
            // מערך שבו נשמור לכל קוד - שנשלף מהטבלה את המספר שהוצמד לו עכשיו
            //var nodesArray = new int[כמות הנקודות שאוחזרו];
            var countNodes = nodes.Count;
            graph = new List<Node>[countNodes];
            visited = new bool[countNodes];
            nodesArray = new int[countNodes];
            for (int i = 0; i < countNodes; i++)
            {
                if (graph[i] == null)
                {
                    graph[i] = new List<Node>();
                }
                visited[i] = false;
                nodesArray[i] = nodes[i].PointId;
                // הוספת צומת חדשה לגרף
                //AddNode();
                //int x = 10;
                // הוספת קשת בין הצומת הנוכחית שנוספה לבין כל שאר צמתי הגרף
                for (int j = i + 1; j < countNodes; j++)
                {
                    if (graph[j] == null)
                    {
                        graph[j] = new List<Node>();
                    }
                    var nodeI = nodes[i].Point;
                    var nodeJ = nodes[j].Point;
                    // source נקודת ה 
                    double x1 = nodeI.PointX;
                    double y1 = nodeI.PointY;
                    // destination נקודת ה 
                    double x2 = nodeJ.PointX;
                    double y2 = nodeJ.PointY;
                    // מציאת המרחק בין 2 הנקודות
                    int distanceInSteps = api.GetDistanceInSteps(x1, y1, x2, y2);
                    Node newNode1, newNode2;
                    if (nodes[i].Point.UserOrCompany == EStatus.User)
                    {
                        newNode1 = new Node(i, j, /*x + i*/distanceInSteps, nodeI.UserPoint.CouponAmount, nodeI.PointX, nodeI.PointY);
                    }
                    else
                    {
                        newNode1 = new Node(i, j, /*x + i*/distanceInSteps, nodeI.CompanyPoint.Coupon.CouponDetail, nodeI.PointX, nodeI.PointY);
                    }
                    if (nodes[j].Point.UserOrCompany == EStatus.User)
                    {
                        newNode2 = new Node(j, i, /*x + i*/distanceInSteps, nodeJ.UserPoint.CouponAmount, nodeJ.PointX, nodeJ.PointY);
                    }
                    else
                    {
                        newNode2 = new Node(j, i, /*x + i*/distanceInSteps, nodes[j].Point.CompanyPoint.Coupon.CouponDetail, nodes[j].Point.PointX, nodes[j].Point.PointY);
                    }
                    AddEdge(newNode1, newNode2);
                }
            }
        }

        // הוספת קשת לגרף
        public void AddNode()
        {
            //graph.Add(new List<Node>());
            //visited.Add(false);
        }

        // הוספת קשת בין 2 הצמתים שנשלחו
        public void AddEdge(Node node1, Node node2)
        {
            // הוספת קשת
            graph[node1.NodeId].Add(node1);
            graph[node2.NodeId].Add(node2);
        }

        //יצירת מסלול שווה ביותר
        // אם יש כמה מסלול עם מקסימום צמתים נבחר את המסלול בעל המשקל המקסימלי
        // CalculateWeight חישוב משקל המסלול
        public int CalculateWeight(List<Node> route)
        {
            int weight = 0;
            for (int i = 0; i < route.Count - 1; i++)
            {
                int node = route[i].NodeId;
                int nextNode = route[i + 1].NodeId;
                foreach (var edge in graph[node])
                {
                    if (edge.NodeId == nextNode)
                    {
                        weight += edge.Weight;
                        break;
                    }
                }
            }
            return weight;
        }

        // מציאת המסלול בעל המשקל המקסימלי מתוך כל המסלולים עם מקסימום הצמתים
        public List<Node> FindBestRoute()
        {
            int maxNodes;
            List<List<Node>> longestRoutes = null;
            FindRoute(source, 0);
            if (routes.Count > 0)
            {
                maxNodes = routes.Max(r => r.Count);
                longestRoutes = routes.Where(r => r.Count == maxNodes).ToList();
            }
            else
            {
                if (closestRoutes.Count > 0)
                {
                    maxNodes = closestRoutes.Max(r => r.Count);
                    longestRoutes = closestRoutes.Where(r => r.Count == maxNodes).ToList();
                }
            }
            if (longestRoutes.Count > 0)
            {
                int maxWeight = int.MinValue;
                List<Node> heaviestRoutes = new List<Node>();
                foreach (var route in longestRoutes)
                {
                    int weight = CalculateWeight(route);
                    if (weight > maxWeight)
                    {
                        maxWeight = weight;
                        heaviestRoutes.Clear();
                        heaviestRoutes = route;
                    }
                }
                return heaviestRoutes;
            }
            else
                return null;
        }

        // מציאת כל המסלולים באורך מסוים או קרוב לאורך הזה ומתוך המסלולים האלה את המסלולים עם הכי הרבה צמתים
        // הפונקציה מקבלת צומת ומספר המייצג את האורך הנוכחי של המסלול
        public void FindRoute(Node node, double currentLength)
        {
            // בדיקה אם האורך הנוכחי של המסלול שווה לאורך הרצוי
            // routes אם כן, אז המסלול הנוכחי מתווסף לרשימת המסלולים
            // הצומת הנוכחי מוסר מהמסלול הנוכחי והפונקציה חוזרת
            if (currentLength == length)
            {
                // מוסיף את הצומת הנוכחי לסוף המסלול הנוכחי
                currentRoute.Add(node);
                // מוסיף רשימה חדשה של צמתים (מסלול) לרשימת המסלולים
                // מעתיק את המסלול הנוכחי כך שהוא לא ישונה ברשימת המסלולים
                routes.Add(new List<Node>(currentRoute));
                // מסיר את הצומת האחרון (הצומת הנוכחי) מהמסלול הנוכחי
                currentRoute.RemoveAt(currentRoute.Count - 1);
                return;
            }
            // מסמן את הצומת הנוכחי כמבוקר
            visited[node.NodeId] = true;
            // מוסיף את הצומת הנוכחי לסוף המסלול הנוכחי
            currentRoute.Add(node);
            // עובר בלולאות דרך כל קצה המחובר לצומת הנוכחי
            foreach (var edge in graph[node.NodeId])
            {
                // numNextNode מגדיר את
                // למזהה הצומת שאליו מוביל הקצה הנוכחי
                int numNextNode = edge.DestinationNode;
                // עובר לולאות דרך כל קצה המחובר לצומת הבא
                foreach (var node1 in graph[numNextNode])
                {
                    // בודק אם הצומת הבא מתחבר בחזרה לצומת הנוכחי
                    if (node1.DestinationNode == node.NodeId)
                    {
                        // nextNode אם כן, מגדיר את 
                        // לצומת הבא שמתחבר בחזרה לצומת הנוכחי
                        nextNode = node1;
                    }
                }
                // edgeLength מגדיר את  
                // לאורך הקצה הנוכחי
                double edgeLength = edge.Length;
                // בודק אם הצומת הבא עדיין לא בוקר
                // והוספת אורך הקצה הנוכחי לאורך הנוכחי אינה חורגת מהאורך המרבי
                if (!visited[nextNode.NodeId] && currentLength + edgeLength <= length)
                {
                    // FindRoute קורא באופן רקורסיבי ל 
                    // עם הצומת הבא והאורך החדש
                    FindRoute(nextNode, currentLength + edgeLength);
                }
            }
            // מסיר את הצומת האחרון (הצומת הנוכחי) מהמסלול הנוכחי
            currentRoute.RemoveAt(currentRoute.Count - 1);
            // מסמן את הצומת הנוכחי כלא בוקר
            visited[node.NodeId] = false;
            // בודק אם האורך הנוכחי של המסלול קטן מהאורך הרצוי
            if (currentLength < length)
            {
                // מחשבת את ההפרש בין האורך הרצוי לאורך הנוכחי
                double lengthDiff = length - currentLength;
                // בודק אם ההפרש קטן מהאורך הקרוב ביותר הנוכחי
                if (lengthDiff < closestLength)
                {
                    // מגדיר את האורך הקרוב ביותר להפרש הנוכחי
                    closestLength = lengthDiff;
                    // מנקה את רשימת המסלולים הקרובים ביותר
                    closestRoutes.Clear();
                }
                // בודק אם ההפרש שווה לאורך הקרוב ביותר הנוכחי
                if (lengthDiff == closestLength)
                {
                    // מוסיף את הצומת הנוכחי לסוף המסלול הנוכחי
                    currentRoute.Add(node);
                    // מוסיף רשימה חדשה של צמתים (מסלול) לרשימת המסלולים הקרובים ביותר
                    // מעתיק את המסלול הנוכחי כך שהוא לא ישונה ברשימת המסלולים הקרובים ביותר
                    closestRoutes.Add(new List<Node>(currentRoute));
                    // מסיר את הצומת האחרון (הצומת הנוכחי) מהמסלול הנוכחי
                    currentRoute.RemoveAt(currentRoute.Count - 1);
                }
            }
        }

        // GetTheBestRoute על יד הפעלת הפונקציה
        // יתקבל המסלול השווה ביותר
        // אחרי שהמשתמש בחר אזור בו הוא מעונין לצעוד
        // נפעיל את הפונקציה
        public List<Node> GetTheBestRoute(int id, double latitude, double longitude, Area area)
        {
            // חישוב אורך המסלול שמגיע למשתמש לצעוד
            //length = CalculateLength(id);
            length = 5009000;
            // שליפת כל הנקודות שנמצאות באזור שבחר
            var allNotRealizedPoints = _publicPointService.GetAllNotRealizedPoints(area).Result;
            if (allNotRealizedPoints.Count > 0)
            {
                //נקודת המוצא שממנה נתחיל להריץ את האלגוריתם למציאת המסלול הטוב ביותר
                //source = המיקום הנוכחי של המשתמש
                var point = new PointDetailsDTO(latitude, longitude, 0);
                var publicPoint = new PublicPointDTO(point);
                // הוספת המיקום הנוכחי לרשימה כדי שיתווסף לגרף - ביצירה
                allNotRealizedPoints.Add(publicPoint);
                // יצירת הגרף
                CreateGraph(allNotRealizedPoints);
                source = graph[0][0];//new Node(0, 0, 0, 0, 0, 0);
                var bestRoute = FindBestRoute();
                bestRoute.RemoveAt(0);
                bestRoute.Reverse();
                // החזרת הקודים של הצמתים לקודים שנמצאים במסד הנתונים
                for (int i = 0; i < bestRoute.Count; i++)
                {
                    bestRoute[i].NodeId = nodesArray[bestRoute[i].NodeId];
                    bestRoute[i].DestinationNode = nodesArray[bestRoute[i].DestinationNode];
                }
                return bestRoute;
            }
            return null;
        }
    }
}
