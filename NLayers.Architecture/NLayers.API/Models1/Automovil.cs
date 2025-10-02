namespace NLayers.API.Models1
{
    using System.ComponentModel.DataAnnotations;

    public class Automovil
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Fabricacion { get; set; }

        [Required]
        public string NumeroMotor { get; set; }

        [Required]
        public string NumeroChasis { get; set; }
    }

}

