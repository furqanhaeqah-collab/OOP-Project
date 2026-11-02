using Buissness_Application.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buissness_Application.Model
{
    public class ProductModel
    {
        public string product_name;
        public float product_price;
        public string product_code;
        public string product_available;
        public int quantity;
        public ProductModel () { }
        public ProductModel (string product_name, float product_price, string product_code, string product_available, int quantity)
        {
            this.product_name = product_name;
            this.product_price = product_price;
            this.product_code = product_code;
            this.product_available = product_available;
            this.quantity = quantity;
        }
        public override string ToString()
        {
            return product_name + "," + product_price + "," + product_code + "," + product_available + "," + quantity;
        }
    }
}
