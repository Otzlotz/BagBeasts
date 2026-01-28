using BagBeasts.Entities;
using Microsoft.EntityFrameworkCore;

namespace BagBeasts.Data;

public partial class BagBeastsContext : DbContext
{
    public BagBeastsContext()
    {
    }

    public BagBeastsContext(DbContextOptions<BagBeastsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ability> Abilities { get; set; }

    public virtual DbSet<Bbmove> Bbmoves { get; set; }

    public virtual DbSet<Beast> Beasts { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Move> Moves { get; set; }

    public virtual DbSet<BagBeasts.Entities.Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=BagBeasts.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ability>(entity =>
        {
            entity.Property(e => e.AbilityId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Beast>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Move>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<BagBeasts.Entities.Type>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });
        
        modelBuilder.Entity<Bbmove>(entity =>
        {
            entity.HasKey(e => new { e.Bbid, e.MoveId });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
