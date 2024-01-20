using APICrudClient.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace APICrudClient
{
    public class APIGateway : Controller
    {
        private string url = "https://localhost:7296/api/Customer";

        private HttpClient client = new HttpClient();

        public List<Customer> ListCustomer()
        {
            List<Customer> customer = new List<Customer>();
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<Customer>>(result);
                    if (datacol != null) { customer = datacol; }

                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
            }
            catch { }
            return customer;
        }

        public Customer CreateCustomer(Customer customer)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string json = JsonConvert.SerializeObject(customer);
            try
            {
                HttpResponseMessage response = client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Customer>(result);
                    if (data != null) customer = data;

                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
            }
            catch { }
            return customer;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            url = url +"/"+id;
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<Customer>(result);
                    if (datacol != null) { customer = datacol; }
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
            }
            catch { }
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            int id = customer.id;
            url=url+"/"+id;
            string json=JsonConvert.SerializeObject(customer);

            try
            {
                HttpResponseMessage response = client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
               
            }
            catch { }
            return customer;
        }

        public void DeleteCustomer(int id)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            url = url + "/" + id;
           
            try
            {
                HttpResponseMessage response = client.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }

            }
            catch { }           
        }

    }
}
