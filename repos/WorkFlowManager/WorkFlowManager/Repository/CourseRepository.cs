using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlowManager.Data;
using WorkFlowManager.Interface;
using WorkFlowManager.Models;
using WorkFlowManager.ViewModel;

namespace WorkFlowManager.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly WorkFlowManagerContext _context;
        public CourseRepository(WorkFlowManagerContext context)
        {
            _context = context;
        }
        public async Task<CourseModel> AddCourse(CourseModel model)
        {
            var addCourse = new Courses().Assign(model);
            _context.Courses.Add(addCourse);
            await _context.SaveChangesAsync();
            return new CourseModel().Assign(addCourse);
        }

        public async Task<List<CourseModel>> GetAllCourse()
        {
            var allCourse = await _context.Set<Courses>()
              
                 .Select(p => new CourseModel
                 {
                     CourseCode = p.CourseCode,
                     CourseDescription = p.CourseDescription,
                     CourseUnit = p.CourseUnit,
                     Id=p.Id
                 }).ToListAsync();
            return allCourse;
        }

        public async Task<List<CourseModel>> GetCourseByLecturerId(int id)
        {
            var query = await _context.Set<Courses>()
                .Where(p => p.LecturerId == id)
                .Select(p => new CourseModel
                {
                    CourseCode = p.CourseCode,
                    CourseDescription = p.CourseDescription,
                    CourseUnit = p.CourseUnit,
                    LecturerId = p.LecturerId,
                    Id = p.Id
                }).ToListAsync();

            return query;
        }

        public async Task<CourseModel> GetSingleCourse(int id)
        {
            var query = await _context.Set<Courses>().FirstOrDefaultAsync(p => p.Id == id);
            var course = new CourseModel().Assign(query);
           
            return course;
        }
    }
}
