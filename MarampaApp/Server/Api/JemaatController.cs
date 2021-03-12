namespace MarampaApp.Controllers
{
    using System.Threading.Tasks;
    using MarampaApp.Models;
    using MarampaApp.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class JemaatController : ControllerBase
    {
        private readonly JemaatService _jemaatService;

        public JemaatController(JemaatService jemaatService)
        {
            _jemaatService = jemaatService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _jemaatService.Get());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _jemaatService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Keluarga>> Post(Jemaat model)
        {
            try
            {
                var result = await _jemaatService.Post(model);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}