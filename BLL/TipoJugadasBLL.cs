using Microsoft.EntityFrameworkCore;
using ProyectoFinal_AP1.Models;
using ProyectoFinal_AP1.DAL;

namespace ProyectoFinal_AP1.BLL
{
    public class TipoJugadasBLL
    {
        private Contexto contexto;
        public TipoJugadasBLL(Contexto _contexto)
        {
            contexto = _contexto;
        }

        public TipoJugadas? Buscar(int id)
        {
            var tipoJugada = contexto.TipoJugadas.AsNoTracking()
            .FirstOrDefault(t => t.TipoJugadaId == id);

            return tipoJugada;
        }

        public List<TipoJugadas> GetTipoJugadas()
        {
            return contexto.TipoJugadas.AsNoTracking().ToList(); 
        }
    }
}