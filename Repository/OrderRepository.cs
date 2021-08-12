using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NetMVC_Restaurant.Models;
using ASP.NetMVC_Restaurant.ViewModel;

namespace ASP.NetMVC_Restaurant.Repository
{
    public class OrderRepository
    {
        private RestaurantDBEntities objRestaurantDBEntities;

        public OrderRepository()
        {
            objRestaurantDBEntities = new RestaurantDBEntities();
        }
        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Order objOrder = new Order();
            objOrder.CustomerId = objOrderViewModel.CustomerId;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.OrderDate = DateTime.Now;
            objOrder.OrderNumber = String.Format("{0:ddmmmyyyyhhmmss}", DateTime.Now);
            objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;
            objRestaurantDBEntities.Orders.Add(objOrder);
            objRestaurantDBEntities.SaveChanges();
            int OrderId = objOrder.OrderId;
            foreach (var item in objOrderViewModel.ListOfOrderDetailViewModel)
            {
                OrdersDetail objOrdersDetail = new OrdersDetail();
                objOrdersDetail.OrderId = OrderId;
                objOrdersDetail.Discount = item.Discount;
                objOrdersDetail.ItemId = item.ItemId;
                objOrdersDetail.Total = item.Total;
                objOrdersDetail.UnitPrice = item.UnitPrice;
                objOrdersDetail.Quantity = item.Quantity;
                objRestaurantDBEntities.OrdersDetails.Add(objOrdersDetail);
                objRestaurantDBEntities.SaveChanges();

                Transaction objTransaction = new Transaction();

                objTransaction.ItemId = item.ItemId;
                objTransaction.Quantity = (-1) * item.Quantity;
                objTransaction.TransactionDate = DateTime.Now;
                objTransaction.TypeId = 2;
                objRestaurantDBEntities.Transactions.Add(objTransaction);
                objRestaurantDBEntities.SaveChanges();

            }
            return true;
        }
    }
}