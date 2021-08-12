using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NetMVC_Restaurant.Models;
using ASP.NetMVC_Restaurant.Repository;
using ASP.NetMVC_Restaurant.ViewModel;

namespace ASP.NetMVC_Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantDBEntities objRestaurantDBEntities;
        public HomeController()
        {
            objRestaurantDBEntities = new RestaurantDBEntities();
        }

        // GET: Home
        public ActionResult Index()
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();

            var objMulipleModel = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(
                objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentType()
                );

            return View(objMulipleModel);
        }
        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {

            return Json(objRestaurantDBEntities.Items.Single(model => model.ItemId == itemId).ItemPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewMode)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(objOrderViewMode);
            return Json("Your Order has been Successfully Placed.", JsonRequestBehavior.AllowGet);

        }
    }
}