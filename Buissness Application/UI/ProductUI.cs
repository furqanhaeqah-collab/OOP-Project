using Buissness_Application.Model;
using Buissness_Application.Service;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Buissness_Application.UI
{
    public class ProductUI
    {
        private readonly ProductService _service;
        private List<ProductModel> productlist;
        public ProductUI()
        {
            _service = new ProductService();
            productlist = _service.GetProduct();
        }
        public void AddProductUI(ProductModel product)
        {
            // Code to Take Input for Add Product
            Console.WriteLine("---Add a new Product---");
            Console.Write("Enter the product name: ");
            product.product_name = Console.ReadLine();
            Console.Write("Enter product price: ");
            product.product_price = float.Parse(Console.ReadLine());
            Console.Write("Enter product code: ");
            product.product_code = Console.ReadLine();
            Console.Write("Enter availability of the product(Yes/No): ");
            product.product_available = Console.ReadLine();
            if(product.product_available == "Yes")
            {
                Console.Write("Enter the quantity of Stock: ");
                product.quantity = int.Parse(Console.ReadLine());
            }
            else
            {
                product.quantity = 0;
            }
            _service.AddProductService(product);
            Console.WriteLine("Product Added Successfully");
            Console.ReadKey();
        }
        public void UpdateProductUI(ProductModel product)
        {
            // Code to Take Input for Update Product
            Console.Write("Enter the product code: ");
            string code = Console.ReadLine();
            product = _service.FindByCode(code);
            if (product == null)
            {
                Console.WriteLine("No product found");
                Console.WriteLine("Invalid product code");
            }
            else
            {
                Console.WriteLine("---Update an existing Product---");
                Console.Write("Enter the product name: ");
                product.product_name = Console.ReadLine();
                Console.Write("Enter product price: ");
                product.product_price = float.Parse(Console.ReadLine());
                Console.Write("Enter product code: ");
                product.product_code = Console.ReadLine();
                Console.Write("Enter availability of the product: ");
                product.product_available = Console.ReadLine();
                Console.Write("Enter the quantity of Stock: ");
                if (product.product_available == "Yes")
                {
                    Console.Write("Enter the quantity of Stock: ");
                    product.quantity = int.Parse(Console.ReadLine());
                }
                else
                {
                    product.quantity = 0;
                }
                _service.UpdateProductService(product);
                Console.WriteLine("Product Updated Successfully");
                Console.ReadKey();
            }
        }
        public void SearchProductUI(ProductModel product)
        {
            // Code to Take Input for Search Product
            Console.Write("Enter the product code: ");
            string code = Console.ReadLine();
            product = _service.FindByCode(code);
            if (product == null)
            {
                Console.WriteLine("No product found");
                Console.WriteLine("Invalid product code");
            }
            else
            {
                Console.WriteLine("Name\t\tPrice\tCode\tAvalaibility\tQuantity\tOn Sale\tDiscounted price");
                Console.WriteLine(product.product_name + "\t" + product.product_price + "\t"
                     + product.product_code + "\t" + product.product_available + "\t\t"
                     + product.quantity);
            }
            Console.ReadKey();
        }
        public void DeleteProductUI(ProductModel p1)
        {
            // Code to Delete Product
            Console.Write("Enter the product code: ");
            string code = Console.ReadLine();
            p1 = _service.FindByCode(code);
            if (p1 == null)
            {
                Console.WriteLine("No product found");
                Console.WriteLine("Invalid product code");
            }
            else
            {
                _service.DeleteProductService(p1);
                Console.WriteLine("Product Deleted Successfully");
            }
            Console.ReadKey();
        }
        public int ViewProductMenuUI()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-------- View Product Menu -------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1.All Products");
            Console.WriteLine("2.Catogerized Products");
            Console.WriteLine("3.View Prdoucts with prices(highest to lowest)");
            Console.WriteLine("4.View Prdoucts with prices(lowest to highest)");
            Console.WriteLine("5.Exit");
            Console.Write("Enter your choice: ");
            int view_product_choice = int.Parse(Console.ReadLine());
            return view_product_choice;
        }
        public void ViewAllProductUI()
        {
            Console.Clear();
            Console.WriteLine("Name\t\tPrice\tCode\tAvalaibility\tOn Sale\tPercentage Discount\tDiscounted Price");
            for (int view_index = 0; view_index < productlist.Count; view_index++)
            {
                Console.WriteLine(productlist[view_index].product_name + "\t" + productlist[view_index].product_price + "\t"
                     + productlist[view_index].product_code + "\t" + productlist[view_index].product_available + productlist[view_index].quantity);
            }
            Console.ReadKey();
        }
        public void ViewCategorizedProductUI()
        {
            Console.Clear();
            Console.Write("Enter the Category of the product: ");
            string category = Console.ReadLine();
            if(category == "Clothes" || category == "Shoes" || category == "Jewellery")
            {
                for (int product_no = 0; product_no < productlist.Count; product_no++)
                {
                    string product_code = productlist[product_no].product_code;
                    if (category == "Clothes" && product_code[0] == 'C')
                    {
                        Console.WriteLine("Product Name\tProduct ID\tProduct Price\tProduct In Stock");
                        Console.WriteLine(productlist[product_no].product_name + "\t" + productlist[product_no].product_code + "\t"
                             + productlist[product_no].product_price + "\t" + productlist[product_no].product_available);
                    }
                    else if (category == "Shoes" && product_code[0] == 'S')
                    {
                        Console.WriteLine("Product Name\tProduct ID\tProduct Price\tProduct In Stock");
                        Console.WriteLine(productlist[product_no].product_name + "\t" + productlist[product_no].product_code + "\t"
                             + productlist[product_no].product_price + "\t" + productlist[product_no].product_available);
                    }
                    else if (category == "Jewellery" && product_code[0] == 'J')
                    {
                        Console.WriteLine("Product Name\tProduct ID\tProduct Price\tProduct In Stock");
                        Console.WriteLine(productlist[product_no].product_name + "\t" + productlist[product_no].product_code + "\t"
                             + productlist[product_no].product_price + "\t" + productlist[product_no].product_available);
                    }
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No such category available");
            }
        }
        public void ViewSortedDescProductsUI()
        {
            Console.Clear();
            productlist = _service.GetSortedDesc();
            for (int sort = 0; sort < productlist.Count; sort++)
            {
                Console.WriteLine("Product Name\tProduct ID\tProduct Price\tProduct In Stock");
                Console.WriteLine(productlist[sort].product_name + "\t" + productlist[sort].product_code + "\t"
                     + productlist[sort].product_price + "\t" + productlist[sort].product_available);
            }
            Console.ReadKey();
        }
        public void ViewSortedAscProductUI()
        {
            Console.Clear();
            productlist = _service.GetSortedAsc();
            for (int sort = 0; sort < productlist.Count; sort++)
            {
                Console.WriteLine("Product Name\tProduct ID\tProduct Price\tProduct In Stock");
                Console.WriteLine(productlist[sort].product_name + "\t" + productlist[sort].product_code + "\t"
                     + productlist[sort].product_price + "\t" + productlist[sort].product_available);
            }
            Console.ReadKey();
        }
        public void InStockProduct()
        {
            Console.Clear();
            for (int view_index = 0; view_index < productlist.Count; view_index++)
            {
                if (productlist[view_index].product_available == "Yes")
                {
                    Console.WriteLine("Name\t\tAvailability\t\tStock Quantity");
                    Console.WriteLine(productlist[view_index].product_name + "\t\t" + productlist[view_index].product_available + "\t\t"
                         + productlist[view_index].quantity);
                }
            }
            Console.ReadKey();
        }
        public void ExitProgram()
        {
            Console.WriteLine("Exiting Program");
            Console.ReadKey();
        }
        public void InvalidOption()
        {
            Console.WriteLine("Invalid Choice");
            Console.ReadKey();
        }
    }
}
