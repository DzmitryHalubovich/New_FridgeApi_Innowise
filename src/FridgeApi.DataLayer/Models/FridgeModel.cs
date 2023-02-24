using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.DataLayer.Models
{
    public class FridgeModel
    {
        [Key]
        public int FridgeModelId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set;}
        [MaxLength(4)]
        public int? Year { get; set;}
    }
}
