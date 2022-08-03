using Microsoft.EntityFrameworkCore;
using ProyectoFinal_AP1.Models;
using ProyectoFinal_AP1.DAL;
using System.Linq.Expressions;


namespace ProyectoFinal_AP1.BLL
{
    public partial class UsuariosBLL
    {
        private Contexto _contexto;
        public UsuariosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int Id)
        {
            return _contexto.Usuarios.Any(g => g.UsuarioId == Id);
        }
        public bool Guardar(Usuarios usuario)
        {
            bool paso = false;

            if (!Existe(usuario.UsuarioId))
                paso = Insertar(usuario);
            else
                paso = Modificar(usuario);
            return paso;

        }
        private bool Insertar(Usuarios usuario)
        {
            _contexto.Usuarios.Add(usuario);

            bool insertar = _contexto.SaveChanges() > 0;
            _contexto.Entry(usuario).State = EntityState.Detached;
            return insertar;
        }

        private bool Modificar(Usuarios usuario)
        {
            _contexto.Entry(usuario).State = EntityState.Modified;

            var guardo = _contexto.SaveChanges() > 0;
            _contexto.Entry(usuario).State = EntityState.Detached;
            return guardo;
        }
        public bool Eliminar(Usuarios usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.Entry(usuario).State = EntityState.Deleted;

            bool elimino = _contexto.SaveChanges() > 0;
            _contexto.Entry(usuario).State = EntityState.Detached;
            return elimino;
        }

         public Usuarios? Buscar(int id)
        {
            var usuario = _contexto.Usuarios.AsNoTracking()
            .FirstOrDefault(u => u.UsuarioId == id);

            return usuario;
        }
       
        public List<Usuarios> GetUsuarios()
        {
            return _contexto.Usuarios.AsNoTracking().ToList(); 
        }

    }
}
