using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Context
{
    public class VendaContext : DbContext
    {

        public DbSet<Venda> Dbvendas { get; set; }
        public DbSet<Item> DbItems { get; set; }

        public VendaContext(DbContextOptions<VendaContext> options) : base(options) { }

        public VendaContext() => this.Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseInMemoryDatabase("InMemoriaDb");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Item>()
                .HasKey(x => x.IdItem);

            modelBuilder
                .Entity<Item>()
                .HasOne(x => x.Venda)
                .WithMany();

            modelBuilder
                .Entity<Venda>()
                .HasKey(x => x.IdVenda);

            //modelBuilder
            //    .Entity<Venda>()
            //    .HasMany(x => x.ItemVendido)
            //    .WithOne();

            modelBuilder
                .Entity<Venda>()
                .HasData(new Venda()
                {
                    IdVenda = 1,
                    IdVendedor = 1,
                    Nome = "Messias",
                    Cpf = "555.666.777-88",
                    Telefone = "(81)98888-9999",
                    Email = "Messias@gmail.com",
                    //ItemVendido = new List<Item>() { new Item { Id = 1, Nome = "Celular" } },
                });
        }

    }
}