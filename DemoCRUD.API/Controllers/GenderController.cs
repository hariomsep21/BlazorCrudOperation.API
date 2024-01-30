using DemoCRUD.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DemoCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : Controller
    {

        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }


        /// <summary>
        /// this controller method is used to get list of student through service
        /// </summary>

        [HttpGet("GetListofGender")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGenderList()
        {
            try
            {
                var response = await _genderService.GetGenderList();

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
    }

}