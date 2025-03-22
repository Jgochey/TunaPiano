namespace TunaPiano.Models;

public class Song
{
    public int Id { get; set; }

    public string? Title { get; set; }
    public int Artist_id { get; set; }
    public string? Album{ get; set; }
    public int Length { get; set; }
}
