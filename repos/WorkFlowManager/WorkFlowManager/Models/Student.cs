using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFlowManager.Models
{
    public class Student:BaseModel
    {
        public string StudentName { get; set; }
        public string MatricNumber { get; set; }

        public List<Courses> Courses { get; set; }
    }
}
