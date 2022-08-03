using Microsoft.EntityFrameworkCore;
using ProyectoFinal_AP1.Models;
using ProyectoFinal_AP1.DAL;
using System.Linq.Expressions;

namespace ProyectoFinal_AP1.BLL
{
    public partial class GananciasBLL
    {
        private Contexto _contexto;
        public GananciasBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int Id)
        {
            return _contexto.Ganancias.Any(g => g.GananciaId == Id);
        }
        public bool Guardar(Ganancias ganancia)
        {
            bool paso = false;

            if (!Existe(ganancia.GananciaId))
                paso = Insertar(ganancia);
            else
                paso = Modificar(ganancia);
            return paso;

        }
        private bool Insertar(Ganancias ganancia)
        {
            _contexto.Ganancias.Add(ganancia);

            bool insertar = _contexto.SaveChanges() > 0;
            _contexto.Entry(ganancia).State = EntityState.Detached;
            return insertar;
        }

        private bool Modificar(Ganancias ganancia)
        {
            
            _contexto.Database.ExecuteSqlRaw($"DELETE FROM GananciasDetalle WHERE gananciaId={ganancia.GananciaId};");

            foreach (var Detalle in ganancia.Detalle)
                _contexto.Entry(Detalle).State = EntityState.Added;
            

            _contexto.Entry(ganancia).State = EntityState.Modified;

            var guardo = _contexto.SaveChanges() > 0;
            _contexto.Entry(ganancia).State = EntityState.Detached;
            return guardo;
        }
        public bool Eliminar(Ganancias ganancia)
        {
            _contexto.Ganancias.Add(ganancia);
            _contexto.Entry(ganancia).State = EntityState.Deleted;

            bool elimino = _contexto.SaveChanges() > 0;
            _contexto.Entry(ganancia).State = EntityState.Detached;
            return elimino;
        }


        public Ganancias? Buscar(int ganancia)
        {
            return _contexto.Ganancias
                .Include(g => g.Detalle)
                .Where(g => g.GananciaId == ganancia)
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
        public List<Ganancias> GetList(Expression<Func<Ganancias,bool>> criterio)
        {
            return _contexto.Ganancias
            .AsNoTracking()
            .Where(criterio)
            .ToList();
        }

    }
}
