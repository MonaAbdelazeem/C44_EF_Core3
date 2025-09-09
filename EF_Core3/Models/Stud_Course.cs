using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core3.Models
{
    internal class Stud_Course
    {
        public int Stud_ID { get; set; }
        public Student? Student { get; set; }

        public int Course_ID { get; set; }
        public Course? Course { get; set; }

        public decimal Grade { get; set; }
    }
}
