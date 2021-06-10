using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using parcialdpwa.Models;

namespace parcialdpwa.DAL
{
    public class DiscContext : DbContext
    {
        public DiscContext() : base("DiscContext")
        {
        }

        public virtual DbSet<Artista> Artistas { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cancion> Canciones { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Disco> Discos { get; set; }
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}