using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewEntity.Orders
{
    public class CreateOrder
    {
        public int IdFoodShopBranch { get; set; }
        public ICollection<OrderItemView> Items { get; set; }
    }
}
