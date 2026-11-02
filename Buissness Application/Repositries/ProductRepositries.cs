using Buissness_Application.Model;
using Buissness_Application.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buissness_Application.Repositries
{
    public class ProductRepositries
    {
        private readonly string _ProductFile = "C:\\BSCS_2nd_Semester\\OOP Programming\\Buissness Project\\Buissness Application\\ProductRecord.txt";
        public void SaveObject(ProductModel product)
        {
            using (StreamWriter write = new StreamWriter(_ProductFile, true))
            {
                write.WriteLine(product.ToString());
            }
        }
        public void SaveList(List<ProductModel> ProductList)
        {
            ClearData();
            using (StreamWriter write = new StreamWriter(_ProductFile, false))
            {
                foreach (var i in ProductList)
                {
                    write.WriteLine(i.ToString());
                }
            }
        }
        public string GetField(string record, int field)
        {
            int commaCount = 1;
            string word = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    word = word + record[i];
                }
            }
            return word;
        }
        public List<ProductModel> GetData()
        {
            List<ProductModel> ProductList = new List<ProductModel>();
            ProductModel product = new ProductModel();
            StreamReader read = new StreamReader(_ProductFile);
            string details;
            while ((details = read.ReadLine()) != null)
            {
                product.product_name = GetField(details, 1);
                string product_price = GetField(details, 2);
                product.product_price = float.Parse(product_price);
                product.product_code = GetField(details, 3);
                product.product_available = GetField(details, 4);
                string quantity = GetField(details, 5);
                product.quantity = int.Parse(quantity);
                ProductList.Add(new ProductModel (product.product_name, product.product_price, product.product_code, product.product_available, product.quantity));
            }
            read.Close();
            return ProductList;
        }
        public void ClearData()
        {
            File.WriteAllText(_ProductFile, string.Empty);
        }
    }
}