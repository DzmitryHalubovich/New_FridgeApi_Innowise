using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.DataLayer.DTO
{
    public sealed class FridgeModelDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(4)]
        public string Year { get; set; }
    }
}
