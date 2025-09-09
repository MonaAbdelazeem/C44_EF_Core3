using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core3.Models
{
    internal class Instructor
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public decimal HourRateBouns { get; set; }

        public int Dept_ID { get; set; }
        public Department? Department { get; set; }

        public ICollection<Course_Inst>? Course_Insts { get; set; }
    }
}
