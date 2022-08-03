using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_AP1.Models
{
    public class TipoJugadas
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "El Id debe de estar en el rango{1} y {2}.")]
        public int TipoJugadaId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre de la loteria")]
        public string NombreJugada { get; set; } = "";
    }
}