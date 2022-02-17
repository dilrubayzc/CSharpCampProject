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
            ProductTestMethod(new ProductManager(new EFProductDal()));
        }

        private static void CategoryTestMethod()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName + " " + category.CategoryId);
            }
           
        }

        private static void ProductTestMethod(ProductManager productManager)
        {
            foreach (var product in productManager.GetProductDetaiils())
            {
                Console.WriteLine(product.ProductName + " / " + product.CategoryName);
            }
        }

        private static ProductManager NewMethod()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            return productManager;
        }
    }
}
