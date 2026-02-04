using GestionVehiculos.Model;

namespace GestionVehiculos.BL
{
    //Las reglas que propongo para este laboratorio:
    // Que se agregue solo si el año del carro es mayor  o igual al  2015.
    // Que solo se pueda editar el Modelo.
    //Eliminar solo si el vehículos es de Marca BYD.
    public class AdministradorVehiculos : IAdministradorVehiculos
    {
        private readonly IVehiculoRepository _vehiculosRepository;

        public AdministradorVehiculos(IVehiculoRepository vehiculosRepository)
        {
            _vehiculosRepository = vehiculosRepository;
        }

        public async Task<IEnumerable<Vehiculo>> obtenerListaVehiculosAsync()
        {
            return await _vehiculosRepository.ObtenerTodosAsync();
        }
        public async Task<Vehiculo> obtenerUnVehiculoAsync(int id)
        {
            return await _vehiculosRepository.ObtenerPorIdAsync(id);
        }

        public async Task AgregarVehiculoAsync(Vehiculo vehiculo)
        {
            int anio = vehiculo.anio;
            if (anio >= 2015)
            {
                await _vehiculosRepository.agregarAsync(vehiculo);
            }
        }

        public async Task EditarVehiculoAsync(Vehiculo vehiculo)
        {
            Vehiculo vehiculoActual = await obtenerUnVehiculoAsync(vehiculo.Id);
            if (vehiculoActual != null)
            {
                vehiculoActual.modelo = vehiculo.modelo;
                await _vehiculosRepository.actualizarAsync(vehiculoActual);
            }
        }

        public async Task EliminarVehiculoAsync(int id)
        {
            Vehiculo vehiculoEliminar = await obtenerUnVehiculoAsync(id);
            if (vehiculoEliminar != null)
            {
                if (vehiculoEliminar.marca == Marca.BYD)
                {
                    await _vehiculosRepository.eliminarAsync(id);
                }
            }
        }
    }
}
