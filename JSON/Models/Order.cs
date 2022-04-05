using System;
using System.Collections.Generic;
using System.Text;

namespace JSON.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> orderItems { get; set; }
    }
}
