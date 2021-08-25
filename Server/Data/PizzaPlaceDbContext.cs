using Microsoft.EntityFrameworkCore;
using PizzaParlor.Shared;

namespace PizzaParlor.Server.Data
{
    public class PizzaPlaceDbContext : DbContext
    {
        public PizzaPlaceDbContext(DbContextOptions<PizzaPlaceDbContext> options) 
            : base(options) { }
        public DbSet<Pizza> Pizzas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var pizzaEntity = modelBuilder.Entity<Pizza>();            
            pizzaEntity.HasKey(pizza => pizza.Id);
            pizzaEntity.Property(pizza => pizza.Price).HasColumnType("money");
            pizzaEntity.HasData(
                new Pizza(1, "Pepperoni", 8.99M, Spiciness.Spicy),
                new Pizza(2, "Margarita", 7.99M, Spiciness.None),
                new Pizza(3, "Diabolo", 9.99M, Spiciness.Hot)
            );

            var customerEntity = modelBuilder.Entity<Customer>();
            customerEntity.HasKey(customer => customer.Id);
            customerEntity.HasOne(customer => customer.Order)
            .WithOne(order => order.Customer)
            .HasForeignKey<Order>(
            order => order.CustomerId);
            
            var orderEntity = modelBuilder.Entity<Order>();            
            orderEntity.HasKey(order => order.Id);
            orderEntity.Property(order => order.TotalPrice).HasColumnType("money");
            orderEntity.HasMany(order => order.PizzaOrders)
            .WithOne(pizzaOrder => pizzaOrder.Order);
            modelBuilder.Entity<PizzaOrder>()
            .HasOne(po => po.Pizza)
            .WithMany();
        }
    }
}
