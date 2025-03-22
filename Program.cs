using TunaPiano.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddNpgsql<TunaPianoDbContext>(builder.Configuration["TunaPianoDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Create Song
app.MapPost("/songs", (TunaPianoDbContext db, Song song) =>
{
    db.Song.Add(song);
    db.SaveChanges();
    return Results.Created($"/song/{song.Id}", song);
});

// Delete Song
app.MapDelete("/songs/{songId}", (TunaPianoDbContext db, int songId) =>
{
    Song? song = db.Song.Find(songId);
    if (song == null)
    {
        return Results.NotFound();
    }

    db.Song.Remove(song);
    db.SaveChanges();
    return Results.NoContent();
});

// Update Song
app.MapPut("/songs/{songId}", (TunaPianoDbContext db, int songId, Song song) =>
{
    Song songToUpdate = db.Song.FirstOrDefault(s => s.Id == songId);
    if (songToUpdate == null)
    {
        return Results.NotFound();
    }
    if (songToUpdate.Id != song.Id)
    {
        return Results.BadRequest();
    }

    songToUpdate.Title = song.Title;
    songToUpdate.Artist_id = song.Artist_id;
    songToUpdate.Album = song.Album;
    songToUpdate.Length = song.Length;

    db.SaveChanges();
    return Results.Ok(songToUpdate);
});

// Get all songs
app.MapGet("/songs", (TunaPianoDbContext db) =>
{
    return Results.Ok(db.Song.ToList());
});

// Get Song Details
app.MapGet("/songs/{songId}", (TunaPianoDbContext db, int songId) =>
{
    Song song = db.Song.Find(songId);
    if (song == null)
    {
        return Results.NotFound("Song not found.");
    }

    Artist artist = db.Artist.Find(song.Artist_id);
    if (artist == null)
    {
        return Results.NotFound("Artist not found.");
    }

    
    var SongGenres = from songGenre in db.SongGenre // Start with the SongGenre table
    join genre in db.Genre on songGenre.Genre_id equals genre.Id // Joins the SongGenre table with the Genre table, where the Genre_id in SongGenre matches the Id in Genre.
    where songGenre.Song_id == songId // Filters the results to only include rows where the Song_id in SongGenre matches the songId that was passed in.
    select genre; // Selects the genre object from the Genre table. This should retrieve all the genres associated with the song.

    var songDetails = new
    {
        id = song.Id,
        title = song.Title,
        artist = new
        {
            id = artist.Id,
            name = artist.Name,
            age = artist.Age,
            bio = artist.Bio
        },
        album = song.Album,
        length = song.Length,
        genres = SongGenres.ToList()
    };

    return Results.Ok(songDetails);
});

// Create Artist
app.MapPost("/artists", (TunaPianoDbContext db, Artist artist) =>
{
    db.Artist.Add(artist);
    db.SaveChanges();
    return Results.Created($"/artist/{artist.Id}", artist);
});

// Delete Artist
app.MapDelete("/artists/{artistId}", (TunaPianoDbContext db, int artistId) =>
{
    Artist? artist = db.Artist.Find(artistId);
    if (artist == null)
    {
        return Results.NotFound();
    }

    db.Artist.Remove(artist);
    db.SaveChanges();
    return Results.NoContent();
});

// Update Artist
app.MapPut("/artists/{artistId}", (TunaPianoDbContext db, int artistId, Artist artist) =>
{
    Artist artistToUpdate = db.Artist.FirstOrDefault(a => a.Id == artistId);
    if (artistToUpdate == null)
    {
        return Results.NotFound();
    }
    if (artistToUpdate.Id != artist.Id)
    {
        return Results.BadRequest();
    }

    artistToUpdate.Name = artist.Name;
    artistToUpdate.Age = artist.Age;
    artistToUpdate.Bio = artist.Bio;

    db.SaveChanges();
    return Results.Ok(artistToUpdate);
});

// Get all artists
app.MapGet("/artists", (TunaPianoDbContext db) =>
{
    return Results.Ok(db.Artist.ToList());
});

// Get Artist Details
app.MapGet("/arists/{artistId}", (TunaPianoDbContext db, int artistId) =>
{
    Artist artist = db.Artist.Find(artistId);
    if (artist == null)
    {
        return Results.NotFound();
    }

    var songs = from song in db.Song
                where song.Artist_id == artistId
                select song;

    return Results.Ok(new { artist, songs = songs.ToList() });
});

// Create Genre
app.MapPost("/genres", (TunaPianoDbContext db, Genre genre) =>
{
    db.Genre.Add(genre);
    db.SaveChanges();
    return Results.Created($"/genre/{genre.Id}", genre);
});

// Delete Genre
app.MapDelete("/genres/{genreId}", (TunaPianoDbContext db, int genreId) =>
{
    Genre? genre = db.Genre.Find(genreId);
    if (genre == null)
    {
        return Results.NotFound();
    }

    db.Genre.Remove(genre);
    db.SaveChanges();
    return Results.NoContent();
});

// Update Genre
app.MapPut("/genres/{genreId}", (TunaPianoDbContext db, int genreId, Genre genre) =>
{
    Genre genreToUpdate = db.Genre.FirstOrDefault(g => g.Id == genreId);
    if (genreToUpdate == null)
    {
        return Results.NotFound();
    }
    if (genreToUpdate.Id != genre.Id)
    {
        return Results.BadRequest();
    }

    genreToUpdate.Description = genre.Description;

    db.SaveChanges();
    return Results.Ok(genreToUpdate);
});

// Get all genres
app.MapGet("/genres", (TunaPianoDbContext db) =>
{
    return Results.Ok(db.Genre.ToList());
});

// Get Genre Details
app.MapGet("/genres/{genreId}", (TunaPianoDbContext db, int genreId) =>
{
    Genre genre = db.Genre.Find(genreId);
    if (genre == null)
    {
        return Results.NotFound();
    }

    var songs = from songGenre in db.SongGenre
                join song in db.Song on songGenre.Song_id equals song.Id
                where songGenre.Genre_id == genreId
                select song;

    return Results.Ok(new { genre, songs = songs.ToList() });
});

app.Run();
