using Domain.Entity;
using Domain.ViewEntity.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abtract
{
    public interface IOrderServices
    {
        Task<string> CreateOrder(CreateOrder createOrder, string userName);
        Task<FoodOrder> DetailOrder(string userName, int idOrder);
    }
}
