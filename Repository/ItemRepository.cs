using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NetMVC_Restaurant.Models;

namespace ASP.NetMVC_Restaurant.Repository
{
    public class ItemRepository
    {
        private RestaurantDBEntities objRestaurantDBEntities;
        public ItemRepository()
        {
            objRestaurantDBEntities = new RestaurantDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItem = new List<SelectListItem>();
            objSelectListItem = (from obj in objRestaurantDBEntities.Items
                                 select new SelectListItem
                                 {
                                     Text = obj.ItemName,
                                     Value = obj.ItemId.ToString(),
                                     Selected = true
                                 }).ToList();
            return objSelectListItem;
        }
    }

}