using Microsoft.EntityFrameworkCore;

namespace GestionVehiculos.DA
{
    public class DBContexto : DbContext //Se hereda DbContext (que es una clase del entity frmwk)
    {
        
        public DBContexto(DbContextOptions<DBContexto> options) : base(options) //El parámetro del contructuro  es para la configuración de la clas DbContext.
        {
        }

        public DbSet<Model.Vehiculo> Vehiculos { get; set; }
    }
}
