using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.DataLayer.Models
{
    public class FridgeProduct
    {
        public int FridgeId { get; set; }
        public Fridge Fridge { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

    }
}
