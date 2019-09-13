using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlowManager.ViewModel;

namespace WorkFlowManager.Interface
{
    public interface ICourseRepository
    {
        Task<CourseModel> AddCourse(CourseModel model);
        Task<List<CourseModel>> GetAllCourse();
        Task<CourseModel> GetSingleCourse(int id);
        Task<List<CourseModel>> GetCourseByLecturerId(int id);

    }
}
