using DemoCRUD.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DemoCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : Controller
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }


        /// <summary>
        /// this controller method is used to get list of student through service
        /// </summary>

        [HttpGet("GetListofState")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStateList()
        {
            try
            {
                var response = await _stateService.GetStateList();

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