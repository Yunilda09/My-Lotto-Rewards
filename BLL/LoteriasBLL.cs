using ProyectoFinal_AP1.Models;
using ProyectoFinal_AP1.DAL;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal_AP1.BLL
{
    public class LoteriasBLL
    {
        private Contexto contexto;

        public LoteriasBLL(Contexto _contexto)
        {
            contexto = _contexto;
        }

        public Loterias? Buscar(int id)
        {
            var Loteria = contexto.Loterias.AsNoTracking()
            .FirstOrDefault(l => l.LoteriaId == id);

            return Loteria;
        }
        public List<Loterias> GetLoterias()
        {
            return contexto.Loterias.AsNoTracking().ToList();
        }
    }
}