using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string ProductName { get; set; }
        [Required, StringLength(150)]
        public string Description { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
    }
}
