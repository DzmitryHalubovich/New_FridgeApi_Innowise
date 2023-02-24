using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FridgeApi.DataLayer.Models
{
    public sealed class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int? DefaultQuantity { get; set; }
        [JsonIgnore]
        public List<Fridge> Fridges { get; set; }
        [JsonIgnore]
        public List<FridgeProduct> FridgeProducts { get; set; }

    }
}
