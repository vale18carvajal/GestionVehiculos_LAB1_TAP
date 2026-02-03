using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionVehiculos.Model
{
    [Table("Vehiculo")]
    public class Vehiculo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo de Id es obligatorio")]
        public int anio { get; set; }
        [Required(ErrorMessage = "El campo de anio es obligatorio")]

        public string modelo { get; set; }
        [Required(ErrorMessage = "El campo de modelo es obligatorio")]

        public Marca marca { get; set; }
        //[Required(ErrorMessage = "El campo de marca es obligatorio")]
    }
}
