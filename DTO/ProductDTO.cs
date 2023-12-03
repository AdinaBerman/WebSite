using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public string ProdName { get; set; } = null!;

        public int ProdPrice { get; set; }

        public string? ProdDescription { get; set; }

        public string? Image { get; set; }
    }
}
