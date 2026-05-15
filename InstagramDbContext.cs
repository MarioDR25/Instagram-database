using Microsoft.EntityFrameworkCore;

namespace InstagramDatabase;

public class InstagramDbContext : DbContext
{
        public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Media> MediaFiles { get; set; }
    public DbSet<Follower> Followers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite("Data Source=instagram.db");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .HasMaxLength(30)
            .IsRequired();


        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);    

        modelBuilder.Entity<User>()
            .Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);
        
            
        modelBuilder.Entity<Post>()
            .Property(p => p.Title)
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<Comment>()
            .Property(c => c.Description)
            .HasMaxLength(1000)
            .IsRequired();
        
        modelBuilder.Entity<Media>()
            .Property(m => m.Url)
            .IsRequired();



        modelBuilder.Entity<User>()
            .HasMany(u => u.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Following)
            .WithOne(p => p.UserFrom)
            .HasForeignKey(p => p.UserFromId)
             .OnDelete(DeleteBehavior.Restrict); ;

        modelBuilder.Entity<User>()
            .HasMany(u => u.Followers)
            .WithOne(p => p.UserTo)
            .HasForeignKey(p => p.UserToId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId);

        modelBuilder.Entity<Post>()
            .HasMany(u => u.Comments)
            .WithOne(p => p.Post)
            .HasForeignKey(p => p.PostId);

        modelBuilder.Entity<Post>()
            .HasMany(u => u.MediaFiles)
            .WithOne(p => p.Post)
            .HasForeignKey(p => p.PostId);



        modelBuilder.Entity<Follower>()
            .HasKey(f => new { f.UserFromId, f.UserToId });

    }

}


