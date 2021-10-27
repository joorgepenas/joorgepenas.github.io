using apiBarberShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<MostrarUsu> MostrarUsu { get; set; }
        public DbSet<DataAnalisisEstilista> DataAnalisisEstilista { get; set; }
        public DbSet<CancelarCita> CancelarCita { get; set; }
        public DbSet<HistorialCitas> HistorialCitas { get; set; }
        public DbSet<HoraValidacion> HoraValidacion { get; set; }
        public DbSet<TagCloud> TagCloud { get; set; }
        public DbSet<GraficoBarras> GraficoBarras { get; set; }
        public DbSet<FeedbackPromedio> FeedbackPromedio { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<SendFeed> SendFeed { get; set; }
        public DbSet<MostrarUsu2> MostrarUsu2 { get; set; }
        public DbSet<CitasCliente> CitasCliente { get; set; }
        public DbSet<CitasEstilista> CitasEstilista { get; set; }
        public DbSet<ServiciosUsuario> ServiciosUsuario { get; set; }
        public DbSet<ReservaCita> ReservaCita { get; set; }
        public DbSet<Estilistas> Estilistas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Backup> Backup { get; set; }

        public DbSet<ForgetUser> ForgetUser { get; set; }
    }
}
