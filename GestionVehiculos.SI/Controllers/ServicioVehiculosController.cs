using GestionVehiculos.BL;
using GestionVehiculos.Model;
using Microsoft.AspNetCore.Mvc;

namespace GestionVehiculos.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioVehiculosController : ControllerBase
    {
        private readonly IAdministradorVehiculos _admin;

        public ServicioVehiculosController(IAdministradorVehiculos admin)
        {
            _admin = admin;
        }

        [HttpGet("ObtengaTodos")]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> obtenerListaVehiculos()
        {
            var lista = await _admin.obtenerListaVehiculosAsync();
            return Ok(lista);
        }

        [HttpGet("ObtengaVehiculo")]
        public async Task<ActionResult<Vehiculo>> obtenerVehiculo(int id)
        {
            var vehiculo = await _admin.obtenerUnVehiculoAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return Ok(vehiculo);
        }
        [HttpPost("AgregaVehiculo")]
        public async Task<IActionResult> AgregarVehiculo([FromBody] Vehiculo vehiculo)
        {
            await _admin.AgregarVehiculoAsync(vehiculo);
            return Ok();
        }
        [HttpPut("EditaVehiculo")]
        public async Task<IActionResult> EditarVehiculo([FromBody] Vehiculo vehiculo)
        {
            await _admin.EditarVehiculoAsync(vehiculo);
            return Ok();
        }
        [HttpDelete("EliminaVehiculo")]
        public async Task<IActionResult> EliminarVehiculo(int id)
        {
            await _admin.EliminarVehiculoAsync(id);
            return Ok();
        }
    }
}
