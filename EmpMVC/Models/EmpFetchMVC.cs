using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpMVC.Models
{
    public class EmpFetchMVC
    {
        public int Ps_Number { get; set; }
        public string Employee_Name { get; set; }
        public string Email { get; set; }
        public string Current_skill { get; set; }
        public string Expected_Training { get; set; }
        public string Expected_Training1 { get; set; }
        public string Expected_Training2 { get; set; }
        public string Expected_Training3 { get; set; }

    }
    public class EmpFetchModel
    {
        public int PSNumber { get; set; }
        public string Password { get; set; }
    }

}