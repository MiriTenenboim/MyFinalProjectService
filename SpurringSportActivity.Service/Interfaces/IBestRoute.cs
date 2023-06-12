using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Service.Interfaces
{
    public interface IBestRoute
    {
        // יצירת מסלול שווה ביותר
        List<Node> GetTheBestRoute(int id, double latitude, double longitude, Area area);
        // הוספת צומת חדשה לגרף
        void AddNode();
        // יצירת גרף מהנקודות שהתקבלו
        void CreateGraph(List<PublicPointDTO> nodes);
        // חישוב אורך המסלול שמגיע למשתמש לצעוד
        int CalculateLength(int id);
    }
}
