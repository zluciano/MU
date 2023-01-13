using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniUni.Models
{
    public class Enrollment
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public int DisciplineID { get; set; }

        public double Grade { get; set; }

        public virtual Student Student { get; set; }
        public virtual Discipline Discipline { get; set; }
    }
}