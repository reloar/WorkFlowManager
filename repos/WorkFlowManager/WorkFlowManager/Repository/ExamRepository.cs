using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlowManager.Data;
using WorkFlowManager.Models;
using WorkFlowManager.ViewModel;

namespace WorkFlowManager.Repository
{
    public class ExamRepository
    {
        private readonly WorkFlowManagerContext _context;
        public ExamRepository(WorkFlowManagerContext context)
        {
            _context = context;
        }
       
        public async Task<CourseModel> SelectCourseForExam(int CourseId)
        {
            var query = await _context.Set<Courses>().FirstOrDefaultAsync(p => p.Id == CourseId);
            var course = new CourseModel().Assign(query);
            
            return course;
        }
        //public async Task<CourseModel> GetExamQuestions()
        //{

        //}
    }
}
