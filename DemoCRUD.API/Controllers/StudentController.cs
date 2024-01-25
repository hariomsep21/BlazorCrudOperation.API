using DemoCRUD.DTO.ModelDtos;
using DemoCRUD.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        /// <summary>
        /// this controller method is used to get list of student through service
        /// </summary>

        [HttpGet("GetListofStudent")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentList()
        {
            try
            {
                var response = await _studentService.GetStudentList();

                if (response.Success)
                {
                    return Ok(response.Data);
                }
                else
                {
                    return BadRequest(response.Message);
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// this controller method is used to delete student from database through service
        /// </summary>
        /// <param name="Id"></param>

        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUserInfoSupport(int Id)
        {
            try
            {
                var response = await _studentService.DeleteStudent(Id);

                if (response.Success)
                {
                    return Ok(response.Data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, response.Message);
                }
            }
            catch (ArgumentNullException ex)
            {

                return BadRequest($"Student cannot be null:{ex.Message}");
            }
        }

        [HttpPost("Create")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public

async Task<IActionResult> CreateUserInfoAsync(StudentsDto studentsDto)
        {
            try
            {
                var response = await _studentService.CreateStudent(studentsDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                else
                {
                    if (response.Message == "Username already exists")
                    {
                        return StatusCode(StatusCodes.Status409Conflict, response.Message); // Use specific code for username conflict
                    }
                    else
                    {
                        return BadRequest(response.Message); // Generic bad request for other errors
                    }
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error:{ex.Message}");
            }
        }
        [HttpPut("Update")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStudent(StudentsDto studentsDto)
        {
            try
            {
                var response = await _studentService.UpdateStudent(studentsDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                else
                {
                    if (response.Message == "User not found")
                    {
                        return NotFound(response.Message); // Use specific code for missing user
                    }
                    else if (response.Message == "Username already exists")
                    {
                        return StatusCode(StatusCodes.Status409Conflict, response.Message); // Use specific code for username conflict
                    }
                    else
                    {
                        return BadRequest(response.Message); // Generic bad request for other errors
                    }
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error>{ex.Message}");
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentInfoById(int id)
        {
            try
            {
                var response = await _studentService.GetStudentInfoById(id);
                if (response.Success)
                {
                    return Ok(response.Data);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error>{ex.Message}");
            }
        }
    }
}




