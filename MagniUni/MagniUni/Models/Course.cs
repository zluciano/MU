using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniUni.Models
{
    public class Course
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}