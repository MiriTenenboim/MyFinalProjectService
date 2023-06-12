using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Common.DTO
{
    public class CompaniesDetailsDTO
    {
        // קוד חברה
        public int CompanyId { get; set; }
        // שם חברה
        public string CompanyName { get; set; }
        // כתובת מייל
        public string CompanyEmailAddress { get; set; }
        // סיסמה חברה
        public string CompanyPassword { get; set; }
        // לוגו חברה
        public string CompanyLogo { get; set; }

    }
}
