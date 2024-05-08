using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSamples.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public double UnitPrice { get; set; }
        public Category Category { get; set; }
    }
}
