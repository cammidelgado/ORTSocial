using Microsoft.EntityFrameworkCore;
using ORTSocial.Models;

namespace ORTSocial.Context
{
    public class ORTSocialContext : DbContext
    {
        public ORTSocialContext(DbContextOptions<ORTSocialContext> options) : base(options)
        {
        }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Cartilla> Cartillas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<CartillaMedico> CartillasMedicos { get; set; }
        public DbSet<Familiar> Familiares { get; set; }
        public DbSet<GrupoFamiliar> GruposFamiliares { get; set; }
        public DbSet<TurnoMedico> TurnosMedicos { get; set; }
    }
}
