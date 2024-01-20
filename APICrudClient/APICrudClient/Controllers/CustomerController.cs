using APICrudClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICrudClient.Controllers
{
    public class CustomerController : Controller
    {
        private readonly APIGateway api;

        public CustomerController(APIGateway apigateway)
        {
            api = apigateway;
        }

        public IActionResult Index() { 
            List<Customer> customers;
            customers = api.ListCustomer();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create() {
            Customer cust=new Customer();  
            
            return View(cust);  
        }

        [HttpPost]
        public IActionResult Create(Customer cust)
        {
            api.CreateCustomer(cust);
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            Customer cust;
            cust=api.GetCustomer(id);
            return View(cust);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Customer cust;
           cust= api.GetCustomer(id);

            return View(cust);
        }

        [HttpPost]
        public IActionResult Edit(Customer cust)
        {
            api.UpdateCustomer(cust);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Customer cust = new Customer();
            cust = api.GetCustomer(id);
            return View(cust);
        }

        [HttpPost]
        public IActionResult Delete(Customer cust)
        {
            api.DeleteCustomer(cust.id);
            return RedirectToAction("index");
        }

    }
}
