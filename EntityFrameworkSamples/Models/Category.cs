using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSamples.Models
{
    public enum CategoryName
    {
        TShirt,
        Shirt,
        Jeans,
        Trousers,
        Shorts,
        Skirt,
        Dress,
        Jacket,
        Others
    }
    public class Category
    {
        public int Id { get; set; }
        public CategoryName Name { get; set; }

        public string? Description { get; set; }
    }
}
