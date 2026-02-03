
using GestionVehiculos.Model;

namespace GestionVehiculos.BL
{
    public interface IVehiculoRepository
    {
        Task<Vehiculo> ObtenerPorIdAsync(int id); //Nota: El task es una función asincrona
        Task<IEnumerable<Vehiculo>> ObtenerTodosAsync();
        Task agregarAsync(Vehiculo vehiculo);
        Task actualizarAsync(Vehiculo vehiculo);
        Task eliminarAsync(int id);

    }
}
