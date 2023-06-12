using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Service
{
    public class Node
    {
        // מספור רץ - כל צומת מקבלת קוד יחודי
        public int NodeId { get; set; }
        // המספר של הצומת שאליה מחוברת הצומת הנוכחית - יעודכן אחרי הוספת קשת
        public int DestinationNode { get; set; }
        // אורך הקשת - יתקבל מפונקצית המרחק של גוגל - יחושב בעת הוספת קשת ולא בעת הוספת צומת
        public int Length { get; set; }
        // שווי הצומת - הנתון ילקח ממסד הנתונים - ימולא אחרי השליפה ממסד הנתונים
        public int Weight { get; set; }
        // המיקום של הנקודה על מפת גוגל
        // X מציר ה
        public double X { get; set; }
        // המיקום של הנקודה על מפת גוגל
        // Y מציר ה
        public double Y { get; set; }

        public Node(int nodeId, int destinationNode, int length, int weight, double x, double y)
        {
            NodeId = nodeId;
            NodeId = nodeId;
            DestinationNode = destinationNode;
            Length = length;
            Weight = weight;
            X = x;
            Y = y;
        }
    }
}
