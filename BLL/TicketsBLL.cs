using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ProyectoFinal_AP1.Models;
using ProyectoFinal_AP1.DAL;

namespace ProyectoFinal_AP1.BLL
{
    public class TicketsBLL
    {
        private Contexto _contexto;
        public TicketsBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int Id)
        {
            return _contexto.Tickets.Any(t => t.TicketId == Id);
        }
        public bool Guardar(Tickets ticket)
        {
            bool paso = false;

            if (!Existe(ticket.TicketId))
                paso = Insertar(ticket);
            else
                paso = Modificar(ticket);
            return paso;

        }
        private bool Insertar(Tickets ticket)
        {
            _contexto.Tickets.Add(ticket);

            bool insertar = _contexto.SaveChanges() > 0;
            _contexto.Entry(ticket).State = EntityState.Detached;
            return insertar;
        }

        private bool Modificar(Tickets ticket)
        {

            //buscar el detalle anterior
            var anterior = _contexto.Tickets
           .Where(t => t.TicketId == ticket.TicketId)
           .Include(t => t.Detalle)
           .AsNoTracking()
           .SingleOrDefault();
            //borrar los items del detalle anterior
            _contexto.Database.ExecuteSqlRaw($"DELETE FROM TicketsDetalle WHERE TicketId={ticket.TicketId};");

            _contexto.Entry(ticket).State = EntityState.Modified;

            var guardo = _contexto.SaveChanges() > 0;
            _contexto.Entry(ticket).State = EntityState.Detached;
            return guardo;
        }
        public bool Eliminar(Tickets ticket)
        {
            _contexto.Tickets.Add(ticket);
            _contexto.Entry(ticket).State = EntityState.Deleted;

            bool elimino = _contexto.SaveChanges() > 0;
            _contexto.Entry(ticket).State = EntityState.Detached;
            return elimino;
        }


        public Tickets? Buscar(int ticket)
        {
            return _contexto.Tickets
                .Include(g => g.Detalle)
                .Where(g => g.TicketId == ticket)
                .AsNoTracking()
                .SingleOrDefault();
        }
        
        public string? GetNombreLoteria(int id)
        {
            var loteria = _contexto.Loterias
                .AsNoTracking()
                .FirstOrDefault(v => v.LoteriaId == id);

                return loteria?.NombreLoteria ;
        }
       public string? GetNombreJugada(int tipoJugadaId)
        {
            var tipoJugada = _contexto.TipoJugadas   
                .AsNoTracking()   
                .FirstOrDefault(v => v.TipoJugadaId == tipoJugadaId);

                return tipoJugada?.NombreJugada;
        }
       public List<Tickets> GetList(Expression<Func<Tickets,bool>> criterio)
        {
            return _contexto.Tickets
            .AsNoTracking()
            .Where(criterio)
            .ToList();
        }
    }
}