using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniUni.Models
{
    public class Student
    {
        public int ID { get; set; }

        public int CourseID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual Course Course { get; set; }
    }
}