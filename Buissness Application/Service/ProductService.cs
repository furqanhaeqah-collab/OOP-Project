using Buissness_Application.Model;
using Buissness_Application.Repositries;
using Buissness_Application.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buissness_Application.Service
{
    public class ProductService
    {
        private readonly ProductRepositries _repositry;
        private List<ProductModel> ProductList;
        public ProductService()
        {
            _repositry = new ProductRepositries();
            ProductList = _repositry.GetData();
        }
        public void AddProductService(ProductModel product)
        {
            _repositry.SaveObject(product);
            ProductList = _repositry.GetData();
            ProductList.Add(product);
        }
        public int FindProductIndex(ProductModel product)
        {
            for (int i = 0; i < ProductList.Count; i++)
            {
                if (ProductList[i].product_code == product.product_code)
                {
                    return i;
                }
            }
            return -1;
        }
        public ProductModel FindByCode(string code)
        {
            for (int i = 0; i < ProductList.Count; i++)
            {
                if (ProductList[i].product_code == code)
                {
                    return ProductList[i];
                }
            }
            return null;
        }
        public void UpdateProductService(ProductModel product)
        {
            int i = FindProductIndex(product);
            ProductList[i] = product;
            _repositry.SaveList(ProductList);
        }
        public ProductModel SearchProductService(int found, string code)
        {
            bool isFound = false;
            for (int i = 0; i < ProductList.Count; i++)
            {
                if (ProductList[i].product_code == code)
                {
                    found = i;
                    isFound = true;
                }
            }
            if (isFound == false)
            {
                return null;
            }
            else
            {
                return ProductList[found];
            }
        }
        public void DeleteProductService(ProductModel product)
        {
            ProductList.Remove(product);
            _repositry.SaveList(ProductList);
        }
        public List<ProductModel> GetProduct()
        {
            return ProductList = _repositry.GetData();
        }
        public List<ProductModel> GetSortedDesc()
        {
            return  ProductList = ProductList.OrderByDescending(p => p.product_price).ToList();
        }
        public List<ProductModel> GetSortedAsc()
        {
            return ProductList = ProductList.OrderBy(p => p.product_price).ToList();
        }
    }
}
