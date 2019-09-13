using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFlowManager.ViewModel
{
    public class LecturerModel:BaseModel
    {
        public string LecturerName { get; set; }
        public string LecturerImage { get; set; }
        public string Position { get; set; }
        //  public string EmailAddress { get; set; }
        // public string Password { get; set; }

        public List<CourseModel> Courses { get; set; }
        public List<StudentModel> Students { get; set; }
    }
    public class StudentModel : BaseModel
    {
        public string StudentName { get; set; }
        public string MatricNumber { get; set; }

        public List<CourseModel> Courses { get; set; }
    }
}
