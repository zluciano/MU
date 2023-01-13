using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniUni.Models
{
    public class Teacher
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Salary { get; set; }

        public string Birthday { get; set; }
    }
}