namespace MarampaApp.Controllers
{
    using System.Threading.Tasks;
    using MarampaApp.Models;
    using MarampaApp.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class KeluargaController : ControllerBase
    {
        private readonly KeluargaService _keluargaService;

        public KeluargaController(KeluargaService keluargaService)
        {
            _keluargaService = keluargaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _keluargaService.Get());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _keluargaService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Keluarga>> Post(Keluarga model)
        {
            try
            {
                var result = await _keluargaService.Post(model);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("PostAnggota/{id}")]
        public async Task<ActionResult<Keluarga>> PostAnggota(int id, Jemaat model)
        {
            try
            {
                var result = await _keluargaService.TambahAnggota(id, model);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("DeleteAnggota/{kkid}/{id}")]
        public async Task<ActionResult<Keluarga>> DeleteAnggota(int kkid, int id)
        {
            try
            {
                var result = await _keluargaService.DeleteAnggota(kkid, id);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}