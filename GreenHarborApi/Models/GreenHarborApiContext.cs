using Microsoft.EntityFrameworkCore;

namespace GreenHarborApi.Models
{
  public class GreenHarborApiContext : DbContext
  {
    public DbSet<Compost> Composts { get; set; }
    public DbSet<User> Users { get; set; }

    public GreenHarborApiContext(DbContextOptions<GreenHarborApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Compost>()
      .HasData(
        new Compost { CompostId = 1, Location = "Near road marker 43, by the red barn", Zip = "97222", ContactName = "Jessica", ContactPhone = "", ContactEmail = "", Contents = "Plant Waste" },
        new Compost { CompostId = 2, Location = "Past HR rd, end of the gravel driveway", Zip = "97999", ContactName = "Phineas Whembley", ContactPhone = "XXXXXXXX", ContactEmail = "p.whemblz@thezone.org", Contents = "yhard dhebris" },
        new Compost { CompostId = 3, Location = "Middle of town, near the post office", Zip = "97111", ContactName = "Kari", ContactPhone = "5038887777", ContactEmail = "K@gmail.com", Contents = "Mixed" }
      );
    }
  }
}