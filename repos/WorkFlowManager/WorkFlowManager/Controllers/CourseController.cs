using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkFlowManager.Interface;
using WorkFlowManager.ViewModel;

namespace WorkFlowManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost("addCourse")]
        public async Task<IActionResult> AddNewCourse([FromBody] CourseModel model)
        {           
            var newCourse = await _courseRepository.AddCourse(model);
           
            return Ok(newCourse.ToResponse("Successful"));
        }
        [HttpGet("getCoursebyLecturerId/{id}")]
        public async Task<IActionResult> GetCourseByLecturerId(int Id)
        {
            var coursebyLecturer = await _courseRepository.GetCourseByLecturerId(Id);

            return Ok(coursebyLecturer.ToResponse("Successful"));
        }
        [HttpGet("getsingleCourse/{id}")]
        public async Task<IActionResult> GetSingleCourse(int Id)
        {
            var getCourse = await _courseRepository.GetSingleCourse(Id);

            return Ok(getCourse.ToResponse("Successful"));
        }
        [HttpGet("getAllCourse")]
        public async Task<IActionResult> GetCourses()
        {

            var courses = await _courseRepository.GetAllCourse();

            return Ok(courses.ToResponse("Successful"));
        }
    }
}
