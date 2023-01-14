using System;
using System.Collections.Generic;
using System.Linq;


namespace LinqProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryId=1, CategeoryName="Bilgisayar"},
                new Category{CategoryId=2, CategeoryName="Telefon"}

            };

            List<Product> products = new List<Product>
            {
                new Product{ProductId=1 ,CategoryId=1, ProductName="Acer Laptop",
                    QuantityPerUnit="32 GB Ram", UnitPrice=10500, UnitInStock=5 },
                new Product{ProductId=2 ,CategoryId=1, ProductName="Asus Laptop",
                    QuantityPerUnit="16 GB Ram", UnitPrice=8000, UnitInStock=3 },
                new Product{ProductId=3 ,CategoryId=1, ProductName="Hp Laptop",
                    QuantityPerUnit="8 GB Ram", UnitPrice=6000, UnitInStock=2 },
                new Product{ProductId=4 ,CategoryId=2, ProductName="Samsung Telefon",
                    QuantityPerUnit="4 GB Ram", UnitPrice=5000, UnitInStock=15 },
                new Product{ProductId=5 ,CategoryId=2, ProductName="Apple Telefon",
                    QuantityPerUnit="4 GB Ram", UnitPrice=8500, UnitInStock=0 }
            };
            //Test(products);
            //AnyTest(products);
            //FindTest(products);
            //FindAllTest(products);
            //AscDescTest(products);
            //ClassicLinqTest(products);

            var result = from p in products
                         join c in categories
                         on p.CategoryId equals c.CategoryId
                         where p.UnitPrice>6000
                         orderby p.UnitPrice descending
                         select new ProductDto { ProductId = p.ProductId, CategoryName=c.CategeoryName, ProductName=p.ProductName, UnitPrice=p.UnitPrice };
            
            foreach (var productDto in result)
            {
                Console.WriteLine("{0}---{1}",productDto.ProductName, productDto.CategoryName);
            }

        }

        private static void ClassicLinqTest(List<Product> products)
        {
            var result = from p in products
                         where p.UnitPrice > 6500
                         orderby p.UnitPrice ascending, p.ProductName descending
                         select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void AscDescTest(List<Product> products)
        {
            var result = products.Where(p => p.ProductName.Contains("top")).OrderBy(p => p.UnitPrice).ThenBy(p => p.ProductName);

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FindAllTest(List<Product> products)
        {
            var result = products.FindAll(p => p.ProductName.Contains("top"));
            Console.WriteLine(result);
        }

        private static void FindTest(List<Product> products)
        {
            var result = products.Find(p => p.ProductId == 3);
            Console.WriteLine(result.ProductName);
        }

        private static void Test(List<Product> products)
        {
            Console.WriteLine("Algoritmik-----------");

            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitInStock > 3)
                {
                    Console.WriteLine(product.ProductName);
                }


            }
            Console.WriteLine("Linq-------------");

            var result = products.Where(p => p.UnitPrice > 5000 && p.UnitInStock > 3);

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void AnyTest(List<Product> products)
        {
            var result = products.Any(p => p.ProductName == "Acer Laptop");
            Console.WriteLine(result);
        }
    }

    class ProductDto
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

    }

    class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
    }
    class Category
    {
        public int CategoryId { get; set; }
        public string CategeoryName { get; set; }

    }
}
