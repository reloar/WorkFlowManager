using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFlowManager.Models
{
    public class Lecturer: BaseModel
    {
        public string LecturerName { get; set; }
        public string LecturerImage { get; set; }
        public string Position { get; set; }
      //  public string EmailAddress { get; set; }
       // public string Password { get; set; }

        public List<Courses> Courses { get; set; }
        public List<Student> Students { get; set; }

    }
}
