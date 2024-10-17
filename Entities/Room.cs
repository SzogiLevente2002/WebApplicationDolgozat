using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebApplicationDolgozat.Entities;

public class Room
{
    public int Id { get; set; }

    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    public int Capacity { get; set; }

    public string UserId { get; set; }  

    [JsonIgnore]
    public ApplicationUser User { get; set; }  
    [JsonIgnore]
    public ICollection<Computer> Computers { get; set; } = new List<Computer>();  
}

