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
    public class LecturerRepository : ILecturerRepository
    {
        private readonly WorkFlowManagerContext _context;
        public LecturerRepository(WorkFlowManagerContext context)
        {
            _context = context;
        }
        public async Task<LecturerModel> AddLecturer(LecturerModel model)
        {
            var addLecturer = new Lecturer().Assign(model);
            _context.Lecturers.Add(addLecturer);
            await _context.SaveChangesAsync();
            return new LecturerModel().Assign(addLecturer);
        }

        public async Task<LecturerModel> AssignCourseToLecturer(LecturerModel model)
        {
            var getlecturer = await _context.Lecturers.FirstOrDefaultAsync(l => l.Id == model.Id);
            getlecturer.Courses = model.Courses.Select(x => new Courses()
            {
                CourseCode=x.CourseCode,
                CourseDescription=x.CourseDescription,
                Id=x.Id,
                CourseUnit=x.CourseUnit
            }).ToList();

            await _context.SaveChangesAsync();
            return new LecturerModel().Assign(getlecturer);

        }
        public async Task<List<LecturerModel>> GetAllLecturer()
        {
            var allLecturer = await _context.Set<Lecturer>()

                 .Select(p => new LecturerModel
                 {
                     LecturerName = p.LecturerName,
                     Position = p.Position,
                     LecturerImage = p.LecturerImage

                 }).ToListAsync();
            return allLecturer;
        }
    }
}
