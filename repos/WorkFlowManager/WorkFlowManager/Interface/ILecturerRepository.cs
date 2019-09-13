using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlowManager.ViewModel;

namespace WorkFlowManager.Interface
{
    public interface ILecturerRepository
    {
        Task<LecturerModel> AddLecturer(LecturerModel model);
        Task<LecturerModel> AssignCourseToLecturer(LecturerModel model);
        Task<List<LecturerModel>> GetAllLecturer();
    }
}
