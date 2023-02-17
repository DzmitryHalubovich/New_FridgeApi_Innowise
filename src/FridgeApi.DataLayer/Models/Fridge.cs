using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FridgeApi.DataLayer.Models
{
    public sealed class Fridge
    {
        [Key]
        public int FridgeId { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? OwnerName { get; set; }
        [Required]
        public int FridgeModelId { get; set; }
        public FridgeModel FridgeModel { get; set; }
        public List<Product> Products { get; set; }
        [JsonIgnore]
        public List<FridgeProduct> FridgeProducts { get; set; } 
    }
}
