using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

            //CategoryTestMethod();
            ProductTestMethod();
        }

        private static void CategoryTestMethod()
        {
            //CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            //foreach (var category in categoryManager.GetAll())
            //{
            //    Console.WriteLine(category.CategoryName + " " + category.CategoryId);
            //}

        }

        private static void ProductTestMethod()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            var result = productManager.GetProductDetaiils();
            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static ProductManager NewMethod()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(product.ProductName);
            }

            return productManager;
        }
    }
}
