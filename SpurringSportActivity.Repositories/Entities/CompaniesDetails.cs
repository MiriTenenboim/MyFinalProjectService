using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Entities
{
    public class CompaniesDetails
    {
        // קוד חברה
        [Key]
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
