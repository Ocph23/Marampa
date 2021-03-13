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
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _jemaatService.Get(id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpPut("baptis/{id}")]
        public async Task<ActionResult<Baptis>> PutBaptis(int id, Baptis model)
        {
            try
            {
                var result = await _jemaatService.PutBaptis(id, model);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}