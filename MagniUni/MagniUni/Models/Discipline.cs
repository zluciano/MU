using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniUni.Models
{
    public class Discipline
    {
        public int ID { get; set; }

        public int TeacherID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}