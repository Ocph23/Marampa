namespace MarampaApp.Controllers
{
    using System.Threading.Tasks;
    using MarampaApp.Models;
    using MarampaApp.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class RayonController : ControllerBase
    {
        private readonly RayonService _service;

        public RayonController(RayonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.Get());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.Get(id));
        }


        [HttpPost]
        public async Task<ActionResult<Rayon>> Post(Rayon model)
        {
            try
            {
                var result = await _service.Post(model);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Rayon>> Put(int id, Rayon model)
        {
            try
            {
                var result = await _service.Put(id, model);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var result = await _service.Delete(id);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}