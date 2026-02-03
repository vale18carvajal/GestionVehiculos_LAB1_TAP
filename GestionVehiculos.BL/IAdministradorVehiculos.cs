
using GestionVehiculos.Model;

namespace GestionVehiculos.BL
{
    //Las reglas que propongo para este laboratorio:
    // Que se agregue solo si el año del carro es mayor al 2015.
    // Que solo se pueda editar el Modelo.
    //Eliminar solo si el vehículos es de Marca BYD.
    public interface IAdministradorVehiculos
    {
        Task<IEnumerable<Vehiculo>> obtenerListaVehiculosAsync();
        Task<Vehiculo> obtenerUnVehiculoAsync(int id);
        Task AgregarVehiculoAsync(Vehiculo vehiculo);
        Task EditarVehiculoAsync(Vehiculo vehiculo);
        Task EliminarVehiculoAsync(int id);

    }
}
