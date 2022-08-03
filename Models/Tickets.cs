using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProyectoFinal_AP1.Models
{
    public class Tickets
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "El Id debe de estar en el rango{1} y {2}.")]
        public int TicketId { get; set; }
        public DateTime FechaTicket { get; set; } = DateTime.Now;
        public decimal Monto { get; set; }
        public decimal TotalMonto { get; set; }

        [ForeignKey("TicketId")]
        public List<TicketsDetalle> Detalle { get; set; } = new List<TicketsDetalle>();
        public Tickets()
        {
            FechaTicket = DateTime.Now;
            TicketId = 0;
            Monto = 0;
        }
    }
}