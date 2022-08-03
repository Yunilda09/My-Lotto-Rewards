using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_AP1.Models
{
    public class Loterias
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "El Id debe de estar en el rango{1} y {2}.")]
        public int LoteriaId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre de la loteria")]
        public string? NombreLoteria { get; set; }

       
    }
}