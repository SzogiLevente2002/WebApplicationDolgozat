using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace WebApplicationDolgozat.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? UserName {  get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        [JsonIgnore]
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
