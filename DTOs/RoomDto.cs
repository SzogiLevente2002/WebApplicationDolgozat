using System.ComponentModel.DataAnnotations;

namespace WebApplicationDolgozat.DTOs
{
    public class RoomDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int UserID { get; set; }
    }
}
