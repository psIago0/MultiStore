using Microsoft.EntityFrameworkCore;
using MultiStore.Models;

namespace MultiStore.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MultiStoreModel> MultiStore { get; set; }
        public DbSet<ImportLog> ImportLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=MultiStoreDW;User Id=sa;Password=K@r3n#Str0ngP@ssw0rd;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MultiStoreModel>(entity =>
            {
                entity.ToTable("MultiStore", "stage"); 
                entity.HasKey(e => e.RowID); 
                entity.Property(e => e.RowID).HasColumnName("RowID");
                entity.Property(e => e.OrderID).HasColumnName("OrderID");
                entity.Property(e => e.OrderDate).HasColumnName("OrderDate");
                entity.Property(e => e.ShipDate).HasColumnName("ShipDate"); 
                entity.Property(e => e.ShipMode).HasColumnName("ShipMode");
                entity.Property(e => e.CustomerID).HasColumnName("CustomerID"); 
                entity.Property(e => e.CustomerName).HasColumnName("CustomerName");
                entity.Property(e => e.CustomerAge).HasColumnName("CustomerAge");
                entity.Property(e => e.CustomerBirthday).HasColumnName("CustomerBirthday");
                entity.Property(e => e.CustomerState).HasColumnName("CustomerState");
                entity.Property(e => e.Segment).HasColumnName("Segment");
                entity.Property(e => e.Country).HasColumnName("Country");
                entity.Property(e => e.City).HasColumnName("City");
                entity.Property(e => e.State).HasColumnName("State");
                entity.Property(e => e.RegionalManagerID).HasColumnName("RegionalManagerID"); 
                entity.Property(e => e.RegionalManager).HasColumnName("RegionalManager"); 
                entity.Property(e => e.PostalCode).HasColumnName("PostalCode");
                entity.Property(e => e.Region).HasColumnName("Region");
                entity.Property(e => e.ProductID).HasColumnName("ProductID"); 
                entity.Property(e => e.Category).HasColumnName("Category");
                entity.Property(e => e.SubCategory).HasColumnName("SubCategory");
                entity.Property(e => e.ProductName).HasColumnName("ProductName"); 
                entity.Property(e => e.Sales).HasColumnName("Sales");
                entity.Property(e => e.Quantity).HasColumnName("Quantity");
                entity.Property(e => e.Discount).HasColumnName("Discount");
                entity.Property(e => e.Profit).HasColumnName("Profit");
            });

            modelBuilder.Entity<ImportLog>(entity =>
            {
                entity.ToTable("ImportLog"); 
                entity.HasKey(e => e.Id); 
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.OriginalFileName).HasColumnName("OriginalFileName");
                entity.Property(e => e.CurrentFileName).HasColumnName("CurrentFileName");
                entity.Property(e => e.ImportDate).HasColumnName("ImportDate");
                entity.Property(e => e.DeleteDate).HasColumnName("DeleteDate");
            });
        }
    }
}
