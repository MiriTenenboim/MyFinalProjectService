using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Service.Interfaces
{
    public interface IFindNodes
    {
        // מציאת הנקודות שבמרחק מסוים מהמיקום הנוכחי
        QuadTree OnLoad(int id, double x, double y);
    }
}
