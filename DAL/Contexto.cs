using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_AP1.Models;

namespace ProyectoFinal_AP1.DAL;

public class Contexto : IdentityDbContext
{
    public DbSet<Tickets> Tickets { get; set; } = null!;
    public DbSet<Ganancias> Ganancias { get; set; } = null!;
    public DbSet<Loterias> Loterias { get; set; } = null!;
    public DbSet<TipoJugadas> TipoJugadas { get; set; } = null!;
    public DbSet<Usuarios> Usuarios { get; set; } = null!;
   

    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }
     protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //Loteria
            {
                base.OnModelCreating(modelbuilder );
                modelbuilder.Entity<Loterias>().HasData(
                    new Loterias
                    {
                        LoteriaId = 1,
                        NombreLoteria = "Loteria Nacional"
                    },

                     new Loterias
                     {
                         LoteriaId = 2,
                         NombreLoteria = "Loteria Nacional Noche"
                     },

                     new Loterias
                     {
                         LoteriaId = 3,
                         NombreLoteria = "Loteka"
                     },

                     new Loterias
                     {
                         LoteriaId = 4,
                         NombreLoteria = "LoteDom"
                     },

                     new Loterias
                     {
                         LoteriaId = 5,
                         NombreLoteria = "Leidsa"
                     },

                     new Loterias
                     {
                         LoteriaId = 6,
                         NombreLoteria = "La Primera"
                     },

                     new Loterias
                     {
                         LoteriaId = 7,
                         NombreLoteria = "Loteria Real"
                     });
            }
            /*Tipo de Jugada*/
            {
                modelbuilder.Entity<TipoJugadas>().HasData(
                     new TipoJugadas
                     {
                         TipoJugadaId = 1,
                         NombreJugada = "Juega+"
                     },

                     new TipoJugadas
                     {
                         TipoJugadaId = 2,
                         NombreJugada = "Pega+"
                     },

                     new TipoJugadas
                     {
                         TipoJugadaId = 3,
                         NombreJugada = "Gana+"
                     },

                     new TipoJugadas
                     {
                         TipoJugadaId = 4,
                         NombreJugada = "Quiniela Loteka"
                     },
                     new TipoJugadas
                     {
                         TipoJugadaId = 5,
                         NombreJugada = "Mega Chances"
                     },
                     new TipoJugadas
                     {
                         TipoJugadaId = 6,
                         NombreJugada = "El Extra"
                     },
                     new TipoJugadas
                     {
                         TipoJugadaId = 7,
                         NombreJugada = "Quiniela"
                     },
                     new TipoJugadas
                     {
                         TipoJugadaId = 8,
                         NombreJugada = "Quemaito"
                     },
                     new TipoJugadas
                     {
                         TipoJugadaId = 9,
                         NombreJugada = "Pega3 Mas"
                     },
                     new TipoJugadas
                     {
                         TipoJugadaId = 10,
                         NombreJugada = "Quiniela Leidsa"
                     },
                     new TipoJugadas
                     {
                         TipoJugadaId = 11,
                         NombreJugada = "Loto Pool"
                     },
                     new TipoJugadas
                     {
                         TipoJugadaId = 12,
                         NombreJugada = "Super KinitoTV"
                     },
                     new TipoJugadas
                     {
                         TipoJugadaId = 13,
                         NombreJugada = "Loto Real"
                     },
                     new TipoJugadas
                     {
                         TipoJugadaId = 14,
                         NombreJugada = "Tu Fecha"
                     },
                     new TipoJugadas
                     {
                         TipoJugadaId = 15,
                         NombreJugada = "Pega4"
                     },
                     new TipoJugadas
                     {
                         TipoJugadaId = 16,
                         NombreJugada = "Quiniela"
                     });
            }
        }
}
