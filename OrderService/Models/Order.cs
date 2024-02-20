using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersService.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Status { get; set; }
        public virtual List<OrderLine> Lines { get; set; }
    }
}