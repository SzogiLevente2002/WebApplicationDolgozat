using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Computer
{
    public int Id { get; set; }

    [MaxLength(255)]
    public string Model { get; set; } = string.Empty;

    public DateTime ManufacturedDate { get; set; }

    public int RoomId { get; set; }
    [JsonIgnore]
    public Room Room { get; set; }
}
