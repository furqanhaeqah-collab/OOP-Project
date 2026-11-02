using Buissness_Application.Model;
using Buissness_Application.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Buissness_Application.UI
{
    public class CustomerUI
    {
        private readonly ProductService _PService;
        private readonly CustomerService _service;
        public CustomerUI()
        {
            _PService = new ProductService();
            _service = new CustomerService();

        }
        public void MainHeaderCustomerUI()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Welcome to M & S Brand Management System ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
        public string CustomerMenuUI()
        {
            Console.Clear();
            MainHeaderCustomerUI();
            Console.WriteLine("----Customer Menu----");
            Console.WriteLine("1.View Product");
            Console.WriteLine("2.Search Product");
            Console.WriteLine("3.Filter In Stock Products");
            Console.WriteLine("4.Buy a Product");
            Console.WriteLine("5.Cancel Order");
            Console.WriteLine("6.Send Feedback");
            Console.WriteLine("7.View Feedback");
            Console.WriteLine("8.Search Feedback");
            Console.WriteLine("9.Exit");
            Console.Write("Enter your choice: ");
            string customer_choice = Console.ReadLine();
            return customer_choice;
        }
        public void BuyProductUI(CustomerModel customer, ProductModel product)
        {
            // Code for Bying
            Console.Write("Enter the product code: ");
            string code = Console.ReadLine();
            product = _PService.FindByCode(code);
            if (product == null)
            {
                Console.WriteLine("No product found");
                Console.WriteLine("Invalid product code");
            }
            else
            {
                Console.WriteLine("Product ID: \t" + product.product_code);
                Console.WriteLine("Product name: \t" + product.product_name);
                Console.WriteLine("Product price: \t" + product.product_price);
                customer.ProductCode = product.product_code;
                Console.WriteLine("Customer Credentials");
                Console.Write("Enter your Customer Id: ");
                customer.CustomerId = Console.ReadLine();
                Console.Write("Enter your Customer Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Enter your Address: ");
                customer.Address = Console.ReadLine();
                Console.Write("Enter your Phone No.: ");
                customer.ContactNo = Console.ReadLine();
                Console.Write("Enter your postal code: ");
                customer.PostalCode = int.Parse(Console.ReadLine());
                _service.AddCustomer(customer);
                Console.WriteLine("Product ordered successfully");
            }
        }
        public void CancelOrderUI(CustomerModel customer)
        {
            // Code for Track Order
            Console.WriteLine("Enter Customer Id: ");
            string Id = Console.ReadLine();
            customer = _service.FindCustomer(Id);
            if (customer == null)
            {
                Console.WriteLine("Invalid credentials");
                Console.WriteLine("Try again");
            }
            else
            {
                _service.DeleteCustomer(customer);
                Console.WriteLine("Order Cancelled Succesfully");
            }
        }
    }
}
