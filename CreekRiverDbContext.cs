using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
{
    new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
    new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Red-Tailed Hawk", ImageUrl = "https://tnstateparks.com/assets/images/content-images/campgrounds/252/camp4-714.jpg"},
    new Campsite {Id = 3, CampsiteTypeId = 3, Nickname = "Norther Pintail", ImageUrl = "https://tnstateparks.com/assets/images/content-images/campgrounds/5170/rocky-fork-headwaters_web.jpg"},
    new Campsite {Id = 4, CampsiteTypeId = 4, Nickname = "Canvasback", ImageUrl = "https://tnstateparks.com/assets/images/content-images/campgrounds/6450/stone_door_campground_group_campsite_b.jpeg"},
    new Campsite {Id = 5, CampsiteTypeId = 3, Nickname = "Masked Tityra", ImageUrl = "https://tnstateparks.com/assets/images/content-images/campgrounds/6496/father_adamz_campground_group_campsite.jpeg"},
    new Campsite {Id = 6, CampsiteTypeId = 2, Nickname = "Wrentit", ImageUrl = "https://tnstateparks.com/assets/images/content-images/campgrounds/256/tnstateparks_41582533_small_1-2.jpg"}
});
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, FirstName = "Flora", LastName = "Fortescue", Email = "flowerqueen@hotmail.com"},
            new UserProfile {Id = 2, FirstName = "Fauna", LastName = "Fortescue", Email = "beastboss@hotmail.com"}
        });

        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, CampsiteId = 5, UserProfileId = 2, CheckinDate = new DateTime(2024, 5, 25), CheckoutDate = new DateTime(2024, 5, 31)},
            new Reservation {Id = 2, CampsiteId = 6, UserProfileId = 1, CheckinDate = new DateTime(2024, 5, 27), CheckoutDate = new DateTime(2024, 6, 3)}
        });
    }
}