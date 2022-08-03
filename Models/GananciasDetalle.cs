using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_AP1.Models
{
    public class GananciasDetalle
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "El Id debe de estar en el rango{1} y {2}.")]
        public int GananciaDetalleId { get; set; }
        public int GananciaId { get; set; }
        public int LoteriaId { get; set; }
        public int TipoJugadaId { get; set; }
        public decimal Ganancia { get; set; }
        public decimal Monto { get; set; }
    }
}