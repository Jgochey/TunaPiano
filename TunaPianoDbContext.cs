using Microsoft.EntityFrameworkCore;

namespace TunaPiano.Models;

public class TunaPianoDbContext : DbContext
{

  public DbSet<Song> Song { get; set; }

  public DbSet<Artist> Artist { get; set; }

  public DbSet<Genre> Genre { get; set; }

  public DbSet<SongGenre> SongGenre { get; set; }


  public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> context) : base(context)
  {

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    modelBuilder.Entity<Song>().HasData(new Song[]
    {
        new Song { Id = 123, Title = "Song 1", Artist_id = 456, Album = "Album 1", Length = 180 },
        new Song { Id = 789, Title = "Song 2", Artist_id = 456, Album = "Album 2", Length = 240 },

    });

    modelBuilder.Entity<Artist>().HasData(new Artist[]
     {
            new Artist { Id = 123, Name = "Artist 1", Age = 25, Bio = "Bio 1" },
            new Artist { Id = 456, Name = "Artist 2", Age = 30, Bio = "Bio 2" },
        });

    modelBuilder.Entity<Genre>().HasData(new Genre[]
    {
        new Genre { Id = 123, Description = "Genre 1" },
        new Genre { Id = 456, Description = "Genre 2" },

    });

    modelBuilder.Entity<SongGenre>().HasData(new SongGenre[]
    {
        new SongGenre { Id = 1, Song_id = 123, Genre_id = 123 },
        new SongGenre { Id = 2, Song_id = 123, Genre_id = 456 },
        new SongGenre { Id = 3, Song_id = 789, Genre_id = 123 },

    });
}
}
