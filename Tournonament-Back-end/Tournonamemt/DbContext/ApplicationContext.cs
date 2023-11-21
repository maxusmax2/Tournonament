using Microsoft.EntityFrameworkCore;
using Tournonamemt.Models;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Tournament> tournaments { get; set; } = null!;
    public DbSet<Tour> tours { get; set; } = null!;
    public DbSet<Score> scores { get; set; } = null!;
    public DbSet<Match> matches { get; set; } = null!;
    public DbSet<Group> groups { get; set; } = null!;
    public DbSet<Discipline> disciplines { get; set; } = null!;
    public DbSet<Bracket> brackets { get; set; } = null!;
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tournament>()
            .HasMany(e => e.Participants)
            .WithMany(e => e.Tournaments);
        modelBuilder.Entity<Match>()
            .HasMany(e => e.Participants)
            .WithMany(e => e.Matches);
        modelBuilder.Entity<Group>()
            .HasMany(e => e.Participants)
            .WithMany(e => e.Groups);
        modelBuilder.Entity<Tour>()
            .HasMany(e => e.Participants)
            .WithMany(e => e.Tours);
        modelBuilder.Entity<Tournament>()
            .HasOne(a => a.Bracket)
            .WithOne(a => a.Tournament)
            .HasForeignKey<Bracket>(c => c.TournamentId);
        modelBuilder.Entity<User>()
           .HasMany(a => a.WinTournaments)
           .WithOne(a => a.Winner)
           .HasForeignKey(e => e.WinnerId);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=BMO\SQLEXPRESS01;Database=tournonament;Trusted_Connection=True;");
    }
}
