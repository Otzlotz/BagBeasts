using System;
using System.Collections.Generic;
using BagBeasts;
using BagBeasts.src.Database;
using Microsoft.EntityFrameworkCore;

namespace BagBeasts.src.Database;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AbilityDB> Abilities { get; set; }

    public virtual DbSet<BagbeastsDB> Bagbeasts { get; set; }

    public virtual DbSet<ItemDB> Items { get; set; }

    public virtual DbSet<MoveDB> Moves { get; set; }

    public virtual DbSet<TypeDB> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=simon");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbilityDB>(entity =>
        {
            entity.HasKey(e => e.BagbeastId).HasName("abilities_pkey");

            entity.Property(e => e.BagbeastId)
                .ValueGeneratedNever()
                .HasColumnName("bagbeast_id");
            entity.Property(e => e.AbilityId).HasColumnName("ability_id");
        });

        modelBuilder.Entity<BagbeastsDB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Atk).HasColumnName("atk");
            entity.Property(e => e.Def).HasColumnName("def");
            entity.Property(e => e.Hp).HasColumnName("hp");
            entity.Property(e => e.Initiative).HasColumnName("initiative");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Spa).HasColumnName("spa");
            entity.Property(e => e.Spd).HasColumnName("spd");
            entity.Property(e => e.Type1).HasColumnName("type_1");
            entity.Property(e => e.Type2).HasColumnName("type_2");

            entity.HasMany(d => d.Moves).WithMany(p => p.Bagbeasts)
                .UsingEntity<Dictionary<string, object>>(
                    "BagbeastMove",
                    r => r.HasOne<MoveDB>().WithMany()
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("MoveId"),
                    l => l.HasOne<BagbeastsDB>().WithMany()
                        .HasForeignKey("BagbeastId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Bagbeastid"),
                    j =>
                    {
                        j.HasKey("BagbeastId", "MoveId").HasName("BMId");
                        j.ToTable("BagbeastMoves");
                    });
        });

        modelBuilder.Entity<ItemDB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("items_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<MoveDB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("moves_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Acc).HasColumnName("acc");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Contact).HasColumnName("contact");
            entity.Property(e => e.CritChanceTier).HasColumnName("critChanceTier");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Dmg).HasColumnName("dmg");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Pp).HasColumnName("pp");
            entity.Property(e => e.Prio)
                .HasDefaultValue(0)
                .HasColumnName("prio");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Moves)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("type");
        });

        modelBuilder.Entity<TypeDB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Types_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_uid");

            entity.ToTable("User");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Auth).HasColumnName("auth");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Psw).HasColumnName("psw");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
