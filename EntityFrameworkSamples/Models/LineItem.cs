using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSamples.Models
{
    public class LineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Cost { get; set; }

        public Product? Product { get; set; }

        public LineItem(int quantity, double rabat, Product product)
        {
            UnitPrice = product.UnitPrice;
            Cost = UnitPrice * (1 - rabat);
            Product = product;
            Quantity = quantity;
        }

        protected LineItem() { }
    }
}
