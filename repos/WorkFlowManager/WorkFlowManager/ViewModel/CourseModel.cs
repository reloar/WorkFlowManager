using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFlowManager.ViewModel
{
    public class CourseModel:BaseModel
    {
        public string CourseCode { get; set; }
        public string CourseDescription { get; set; }
        public int CourseUnit { get; set; }
        public int LecturerId { get; set; }
    }
}
