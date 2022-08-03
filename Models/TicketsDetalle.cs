using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_AP1.Models
{
    public class TicketsDetalle
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "El Id debe de estar en el rango{1} y {2}.")]
        public int TicketDetalleId { get; set; }
        public int TicketId { get; set; }
        public int LoteriaId { get; set; }
        public int TipoJugadaId { get; set; }
        public double Ganancia { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El monto debe estar en el rango {1} y {2}")]
        public decimal Monto { get; set; }
    }
}