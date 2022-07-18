using AdsPal.Areas.Identity.Data;
using AdsPal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdsPal.Data;

public class AdsPalContext : IdentityDbContext<ApplicationUser>
{
    public virtual DbSet<Ad> Ads { get; set; } = null!;
    public virtual DbSet<AdsCategory> AdsCategories { get; set; } = null!;
    public virtual DbSet<AdsCorrespondence> AdsCorrespondences { get; set; } = null!;
    public virtual DbSet<AdsMedia> AdsMedias { get; set; } = null!;
    public virtual DbSet<AdsPaymentHistory> AdsPaymentHistories { get; set; } = null!;
    public virtual DbSet<AdsPaymentOption> AdsPaymentOptions { get; set; } = null!;
    public virtual DbSet<AdsSubCategory> AdsSubCategories { get; set; } = null!;
    public virtual DbSet<City> Cities { get; set; } = null!;
    
    public AdsPalContext(DbContextOptions<AdsPalContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Ad>(entity =>
        {
            entity.HasKey(e => e.AdsId)
                .HasName("PK_Ads_1");

            entity.Property(e => e.Brand).HasMaxLength(50);

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.Property(e => e.UserId).HasMaxLength(200);

            entity.HasOne(d => d.City)
                .WithMany(p => p.Ads)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ads_City");

          

            entity.HasOne(d => d.SubCategory)
                .WithMany(p => p.Ads)
                .HasForeignKey(d => d.SubCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ads_AdsSubCategory");
        });

        modelBuilder.Entity<AdsCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId)
                .HasName("PK_Categories");

            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });


        modelBuilder.Entity<AdsCorrespondence>(entity =>
        {
            entity.HasKey(e => e.ChatCorrespondenceId);

            entity.ToTable("AdsCorrespondence");

            entity.Property(e => e.ChatCorrespondenceId).ValueGeneratedNever();

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.Property(e => e.FromUserId).HasMaxLength(50);

            entity.Property(e => e.ToUserId).HasMaxLength(50);

            entity.HasOne(d => d.Ads)
                .WithMany(p => p.AdsCorrespondences)
                .HasForeignKey(d => d.AdsId)
                .HasConstraintName("FK_AdsCorrespondence_Ads");
        });

        modelBuilder.Entity<AdsMedia>(entity =>
        {
            entity.HasKey(e => e.AdsImageId);

            entity.Property(e => e.AdsImageId).ValueGeneratedNever();

            entity.Property(e => e.AdsImageFileType).HasMaxLength(10);

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.Property(e => e.OriginalFileName).HasMaxLength(200);

            entity.HasOne(d => d.Ads)
                .WithMany(p => p.AdsMedia)
                .HasForeignKey(d => d.AdsId)
                .HasConstraintName("FK_AdsMedias_Ads");
        });

        modelBuilder.Entity<AdsPaymentHistory>(entity =>
        {
            entity.HasKey(e => e.AdsPaymentId);

            entity.ToTable("AdsPaymentHistory");

            entity.Property(e => e.AdsPaymentId).ValueGeneratedNever();

            entity.Property(e => e.Amount).HasColumnType("money");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.Property(e => e.CreditCardNo).HasMaxLength(50);

            entity.Property(e => e.CryptoAddress).HasMaxLength(200);

            entity.Property(e => e.CryptoTransactionNo).HasMaxLength(200);

            entity.HasOne(d => d.Ads)
                .WithMany(p => p.AdsPaymentHistories)
                .HasForeignKey(d => d.AdsId)
                .HasConstraintName("FK_AdsPaymentHistory_Ads1");

            entity.HasOne(d => d.AdsPaymentOption)
                .WithMany(p => p.AdsPaymentHistories)
                .HasForeignKey(d => d.AdsPaymentOptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdsPaymentHistory_AdsPaymentOption");
        });

        modelBuilder.Entity<AdsPaymentOption>(entity =>
        {
            entity.ToTable("AdsPaymentOption");

            entity.Property(e => e.AdsPaymentOptionCharge).HasColumnType("money");

            entity.Property(e => e.AdsPaymentOptionLabel).HasMaxLength(100);
        });

        

        modelBuilder.Entity<AdsSubCategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoryId)
                .HasName("PK_SubCategory");

            entity.ToTable("AdsSubCategory");

            entity.Property(e => e.SubCategoryId).ValueGeneratedNever();

            entity.Property(e => e.Description).HasMaxLength(50);

            entity.HasOne(d => d.Category)
                .WithMany(p => p.AdsSubCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdsSubCategory_AdsCategories");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.CityName).HasMaxLength(100);
        });

        

        

        //OnModelCreatingPartial(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
