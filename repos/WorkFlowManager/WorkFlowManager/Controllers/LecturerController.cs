using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkFlowManager.Interface;
using WorkFlowManager.ViewModel;

namespace WorkFlowManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly ILecturerRepository _lecturerRepository;
        public LecturerController(ILecturerRepository lecturerRepository)
        {
            _lecturerRepository = lecturerRepository;
        }

        [HttpPost("addlecturer")]
        public async Task<IActionResult> AddNewLecturer([FromBody] LecturerModel model)
        {
            var newlecturer = await _lecturerRepository.AddLecturer(model);

            return Ok(newlecturer.ToResponse("Successful"));
        }
        [HttpPost("assignCourse")]
        public async Task<IActionResult> AssignCourse([FromBody] LecturerModel model)
        {
            var newCourse = await _lecturerRepository.AssignCourseToLecturer(model);

            return Ok(newCourse.ToResponse("Successful"));
        }
        [HttpGet("getAllLecturer")]
        public async Task<IActionResult> GetCourses()
        {

            var lecturers = await _lecturerRepository.GetAllLecturer();

            return Ok(lecturers.ToResponse("Successful"));
        }
    }
}