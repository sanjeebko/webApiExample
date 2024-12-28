using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private string[] studentNames;
        public StudentsController()
        {
            studentNames = ["tom", "harry", "britney", "john", "karen"];
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(studentNames);
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            return Ok($"Get student with id {id}");
        }
        [HttpPost]
        public IActionResult CreateStudent()
        {
            return Ok("Create student");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id)
        {
            return Ok($"Update student with id {id}");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok($"Delete student with id {id}");
        }
    }
}
