using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal TotalPrice => (UnitPrice ?? 0) * Quantity;
    }
}
