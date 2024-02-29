using Data;
using Data.Abtract;
using Domain.ConstValue.Orders;
using Domain.Entity;
using Domain.ViewEntity.Orders;
using Service.Abtract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderServices:IOrderServices
    {
        IRepository<FoodOrder> _foodOrdersRepo;
        IDapperHelper _dapperHelper;

        public OrderServices(IRepository<FoodOrder> foodOrdersRepo, IDapperHelper dapperHelper)
        {
            _foodOrdersRepo = foodOrdersRepo;
            _dapperHelper = dapperHelper;
        }

        public async Task<string> CreateOrder(CreateOrder createOrder, string userName)
        {
            var order = new FoodOrder();
            order.IdFoodShopBranch = createOrder.IdFoodShopBranch;
            order.CreateDate = DateTime.Now;
            order.OrderStatus = OrderStatus.NEW;

            #region Add id User
            var user = await _dapperHelper
                .ExecuteReturnFirst<User>
                ($"Select id from AspNetUsers where UserName = '{userName}'");
            order.IdUser = user.Id;
            #endregion

            #region dapper get list food
            string queryWhere = "select * from food where ";
            int countWhere = 0;

            foreach (var i in createOrder.Items.Select(i => i.IdFood))
            {
                countWhere++;
                queryWhere =  countWhere < createOrder.Items.Count
                                ?  queryWhere + "id = " + i + " or "
                                : queryWhere + "id = " + i;
            }

            var foods = await _dapperHelper.ExecuteSqlGetList<Food>(queryWhere);
            #endregion

            #region Handle TotalAmount and TotalPrice
            order.TotalAmount = createOrder.Items.Sum(c => c.Quantity);
            order.TotalPrice = 0;
            foreach (var i in foods)
            {
                order.TotalPrice = 
                    order.TotalPrice + 
                    (i.Price - (i.DiscountAmount!=null 
                            ? i.DiscountAmount.Value 
                            : 0))
                            * createOrder.Items
                            .FirstOrDefault(c => c.IdFood == i.id).Quantity;
            }
            #endregion

            #region Mapper OrderItems
            foreach (var i in createOrder.Items)
            {
                OrderItem oi = new OrderItem();
                oi.IdFood = i.IdFood;
                oi.IdFoodOrder = order.Id;
                oi.Quantity = i.Quantity;
                var food = foods.FirstOrDefault(f => f.id == i.IdFood);
                oi.Price = food.Price -  (food.DiscountAmount != null ?food.DiscountAmount.Value : 0);
                order.OrderItems.Add(oi);
            }
            #endregion

            await _foodOrdersRepo.Insert(order);
            await _foodOrdersRepo.Commit();

            return null;
        }

        public async Task<FoodOrder> DetailOrder(string userName, int idOrder)
        {
            FoodOrder order = new FoodOrder();
            try
            {
                order = await _dapperHelper
                .ExecuteReturnFirst<FoodOrder>
                ($"select * " +
                $"from " +
                $"(select * from FoodOrder where id = {idOrder}) a, " +
                $"(select id as IdUser from AspNetUsers where UserName = '{userName}') b " +
                $"where a.IdUser = b.IdUser");

                var orderItem = await _dapperHelper.ExecuteSqlGetList<OrderItem>("Select * from OrderItem where IdFoodOrder = " + idOrder);
                order.OrderItems = orderItem.ToList();
                order.IdUser = null;
                return order;
            }
            catch
            {
                return null;
            }           
        }
    }
}
