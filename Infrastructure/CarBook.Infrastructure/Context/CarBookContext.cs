using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Infrastructure.Context
{
    public class CarBookContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NFEPLMA\\SQLEXPRESS;initial catalog=UgurBitirmeDb;integrated security =true;TrustServerCertificate=True");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAdress> FooterAdresses { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TagCloud> TagClouds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RentACar> RentACars { get; set; }
        public DbSet<RentACarProcess> RentACarProcesses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // ← BU SATIR EKSİK!

            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.PickUpLocation)
                .WithMany(x => x.PickUpReservation)
                .HasForeignKey(x => x.PickUpLocationID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.DropOffLocation)
                .WithMany(x => x.DropOffReservation)
                .HasForeignKey(x => x.DropOffLocationID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
//🔹 OnModelCreating nedir?
//Bu metot, Entity Framework’te veritabanı modeli (tablolar, ilişkiler, kurallar) oluşturulurken özelleştirme yapmak için kullanılır.
//Yani EF senin entity’lerinden (C# sınıflarından) veritabanı tablosu üretirken, ilişkileri, kısıtlamaları, yabancı anahtarları vs. burada tanımlarsın.
//➡️ Kısaca:
//“Veritabanı nasıl oluşturulacak, hangi tablolar nasıl bağlanacak” bilgisini burada söylersin.

//ModelBuilder nedir?
//modelBuilder bu işlemi inşa eden araçtır.
//Yani EF’e “şu entity’yi şöyle kur, şu tabloyu şöyle ilişkilendir” dediğin yardımcı nesnedir.
//➡️ Kısaca:
//“Tabloların mimarisini kuran inşaat ustası” gibi düşün.
//Sen ona “Reservation şu tabloyla ilişkili olsun” diyorsun, o da ilişkiyi veritabanına uygulatıyor.


//modelBuilder.Entity<Reservation>()
//Reservation entity'si üzerinde yapılandırma başlatılıyor.
//csharp.HasOne(x => x.PickUpLocation)
//Bir Reservation'ın bir tane PickUpLocation'ı vardır.
//x => x.PickUpLocation: Navigation property(gezinme özelliği)
//csharp.WithMany(x => x.PickUpReservation)
//Bir PickUpLocation'ın birden fazla Reservation'ı olabilir.
//x => x.PickUpReservation: Ters yöndeki koleksiyon property
//csharp.HasForeignKey(x => x.PickUpLocationID)
//Foreign key (yabancı anahtar) olarak PickUpLocationID kullanılıyor.
//Bu alan Reservation tablosunda bulunur ve PickUpLocation tablosunun primary key'ine referans verir.
//csharp.OnDelete(DeleteBehavior.ClientSetNull)
//Silme davranışı belirleniyor.
//ClientSetNull: PickUpLocation silindiğinde, ilişkili Reservation kayıtları veritabanında silinmez.


