using System.ComponentModel.DataAnnotations;

namespace WebApplicationDolgozat.DTOs
{
    public class ComputerDto
    {
        public int ID { get; set; }

        public string Model { get; set; }


        public DateTime ManufacturedDate { get; set; }

        public int RoomId { get; set; }
    }
}
