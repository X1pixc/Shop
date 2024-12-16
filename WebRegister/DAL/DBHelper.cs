using Microsoft.EntityFrameworkCore;
using WebRegister.DAL.Models;

namespace WebRegister.DAL;

public class DBHelper: DbContext
{
    public DbSet<UserModel> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Register;Username=postgres;Password=12345");
    }
    public DbSet<SessionModel> Sessions { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<ProfileModel> Profiles { get; set; }
    public DbSet<BasketModel> Baskets { get; set; }
    public DbSet<BasketProductsModel> BasketProducts { get; set; }


    public DBHelper()
    {
        Database.EnsureCreated();
    }
}