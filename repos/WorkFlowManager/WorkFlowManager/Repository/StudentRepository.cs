using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlowManager.Data;
using WorkFlowManager.ViewModel;

namespace WorkFlowManager.Repository
{
    public class StudentRepository
    {
        private readonly WorkFlowManagerContext _context;
        public StudentRepository(WorkFlowManagerContext context)
        {

            _context = context;
        }
        //public async Task<StudentModel> RegisterCourse(CourseModel course)
        //{

        //}
    }
}
