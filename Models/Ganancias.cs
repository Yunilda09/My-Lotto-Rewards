using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_AP1.Models
{
    public class Ganancias
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "El Id debe de estar en el rango{1} y {2}.")]
        public int GananciaId { get; set; }
        public DateTime FechaGanancia { get; set; } = DateTime.Now;
        public decimal Monto { get; set; }
        public decimal TotalGanancia { get; set; }

        [ForeignKey("GananciaId")]
        public List<GananciasDetalle> Detalle { get; set; } = new List<GananciasDetalle>();
        public Ganancias()
        {
            FechaGanancia = DateTime.Now;
            GananciaId = 0;
            Monto = 0;
        }
    }
}