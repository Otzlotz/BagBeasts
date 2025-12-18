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

    public virtual DbSet<Ability> Abilities { get; set; }

    public virtual DbSet<Bagbeasts> Bagbeasts { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Move> Moves { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=simon;Persist Security Info=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("abilities_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Bagbeasts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Id");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Atk)
                .HasDefaultValueSql("0")
                .HasColumnName("atk");
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
                    r => r.HasOne<Move>().WithMany()
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("MoveId"),
                    l => l.HasOne<Bagbeasts>().WithMany()
                        .HasForeignKey("BagbeastId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Bagbeastid"),
                    j =>
                    {
                        j.HasKey("BagbeastId", "MoveId").HasName("BMId");
                        j.ToTable("BagbeastMoves");
                    });
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("items_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Move>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("moves_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Type>(entity =>
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
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Psw).HasColumnName("psw");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
