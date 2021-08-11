using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NetMVC_Restaurant.Models;

namespace ASP.NetMVC_Restaurant.Repository
{
    public class PaymentTypeRepository
    {
        private RestaurantDBEntities objRestaurantDBEntities;
        public PaymentTypeRepository()
        {
            objRestaurantDBEntities = new RestaurantDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            var objSelectListItem = new List<SelectListItem>();
            objSelectListItem = (from obj in objRestaurantDBEntities.PaymentTypes
                                 select new SelectListItem
                                 {
                                     Text = obj.PaymentTypeName,
                                     Value = obj.PaymentTypeId.ToString(),
                                     Selected = true
                                 }).ToList();
            return objSelectListItem;
        }
    }
}