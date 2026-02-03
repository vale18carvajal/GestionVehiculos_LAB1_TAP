using GestionVehiculos.BL;
using GestionVehiculos.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionVehiculos.DA
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly DBContexto _context;

        public VehiculoRepository(DBContexto context)
        {
            this._context = context;
        }

        //READ
        public async Task<Vehiculo> ObtenerPorIdAsync(int id)
        {
            return await this._context.Vehiculos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Vehiculo>> ObtenerTodosAsync()
        {
            return await this._context.Vehiculos.ToListAsync();
        }

        //CREATE
        public async Task agregarAsync(Vehiculo vehiculo)
        {
            await this._context.Vehiculos.AddAsync(vehiculo);
            await this._context.SaveChangesAsync();
        }
        
        //UPDATE
        public async Task actualizarAsync(Vehiculo vehiculo)
        {
            this._context.Vehiculos.Update(vehiculo); //Nota: No se ejecuta con await para la función Update del EF
            await this._context.SaveChangesAsync();
        }

        //DELETE
        public async Task eliminarAsync(int id)
        {
            Vehiculo vehiculo = await this.ObtenerPorIdAsync(id);
            if (vehiculo !=  null)
            {
                this._context.Vehiculos.Remove(vehiculo);
                await this._context.SaveChangesAsync();
            }

        }
        //Nota: Todas las funciones asincronas terminan en async aunque yo las crea, y siempre aplciar el await cuando se llaman
    }
}
