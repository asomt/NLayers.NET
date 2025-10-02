using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayers.Entites.Entities
{
    public class Automovil
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public  required string Marca { get; set; }

        [Required]
        public required string Modelo { get; set; }

        [Required]
        public required string Color { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Fabricacion { get; set; }

        [Required]
        public required string NumeroMotor { get; set; }

        [Required]
        public required string NumeroChasis { get; set; }

    }
}
