using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileIO_JSON_Serialize.Desrialize
{
    public class ProductService
    {
        public static string PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "example.txt");
        List<Product> Products = new List<Product>();
        public void CreateProduct(Product product)
        {
            string[] JsonFormat=new string[1];

            JsonFormat[0] = JsonSerializer.Serialize(product);
            File.AppendAllLines(PATH, JsonFormat);
        }
        
        public Product GetProduct(int id)
        {
            Product? getProduct = new Product("NULL", 0,0);
            if (id <= Product.ID && Product.ID >= 0)
            {
                string[] codes = File.ReadAllLines(PATH);
                foreach (var code in codes)
                {
                    Product product;
                    product = JsonSerializer.Deserialize<Product>(code);
                    if (product.Index == id)
                    {
                        getProduct = product;
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException("There is not Product with this ID !");
            }
            return getProduct;
        }
        public void Delete(int id)
        {
            string[] codes = File.ReadAllLines(PATH);
                Product product;
            foreach (var code in codes)
            {
                product = JsonSerializer.Deserialize<Product>(code);

            }
            Products.RemoveAll(p => p.Index == id);
            string newCodes = JsonSerializer.Serialize(Products)+Products.Count;
            File.WriteAllText(PATH, newCodes);
        }
        public  List<Product> GetAllProducts()
        {
            List<Product>? getProducts = new List<Product>();
            string[] codes = File.ReadAllLines(PATH);
            foreach (var code in codes)
            {
                Product product;
                product = JsonSerializer.Deserialize<Product>(code);
                getProducts.Add(product);
            }
            return getProducts;
        }
    }
}
