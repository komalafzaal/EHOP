using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EHOP.Models;

public partial class EhopContext : DbContext
{
    public EhopContext()
    {
    }

    public EhopContext(DbContextOptions<EhopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buyer> Buyers { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EHOP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__buyers__3214EC07541A252B");

            entity.ToTable("buyers");

            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07E98EC04E");

            entity.ToTable("sellers");

            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    private const string _systemUserId = "2fd28110-93d0-427d-9207-d55dbca680fa";

    public override int SaveChanges()
    {
        var tracker = ChangeTracker;

        foreach (var entry in tracker.Entries())
        {
            if (entry.Entity is FullAuditModel)
            {
                var referenceEntity = entry.Entity as FullAuditModel;
                switch (entry.State)
                {
                    case EntityState.Added:
                        referenceEntity.CreatedDate = DateTime.Now;
                        if (string.IsNullOrWhiteSpace(referenceEntity.CreatedByUserId))
                        {
                            referenceEntity.CreatedByUserId = _systemUserId;
                        }
                        break;
                    case EntityState.Deleted:
                    case EntityState.Modified:
                        referenceEntity.LastModifiedDate = DateTime.Now;
                        if (string.IsNullOrWhiteSpace(referenceEntity.LastModifiedUserId))
                        {
                            referenceEntity.LastModifiedUserId = _systemUserId;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return base.SaveChanges();
    }
}
