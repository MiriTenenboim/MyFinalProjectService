using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Entities
{
    public class UsersDetails
    {
        [Key]
        // קוד לקוח
        public int UserId { get; set; }
        // שם פרטי לקוח
        public string UserFirstName { get; set; }
        // שם משפחה לקוח
        public string UserLastName { get; set; }
        // שם משתמש
        public string UserName { get; set; }
        // כתובת מייל לקוח
        public string UserEmailAddress { get; set; }
        // סיסמה לקוח
        public string UserPassword { get; set; }
        // מספר בנק
        public int UserBank { get; set; }
        // מספר סניף הבנק
        public int UserBankBranch { get; set; }
        // מספר חשבון בנק
        public int UserBankAccount { get; set; }
    }
}
