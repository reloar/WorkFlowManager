using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFlowManager.Models
{
    public class Courses: BaseModel
    {
        public int CoursesId { get; set; }
       public string CourseCode { get; set; }
       public string CourseDescription { get; set; }
       public int CourseUnit { get; set; }
        public int LecturerId { get; set; }
        public int StudentId { get; set; }
        public Question Questions { get; set; }
    }
}
