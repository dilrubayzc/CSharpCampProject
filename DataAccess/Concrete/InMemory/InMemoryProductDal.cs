using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>() {
                new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{CategoryId=4,ProductId=2,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{CategoryId=2,ProductId=3,ProductName="Telefon",UnitPrice=1500,UnitsInStock=30},
                new Product{CategoryId=2,ProductId=4,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{CategoryId=3,ProductId=5,ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)//Eğer ben direk gönderdiğim productı silmeye çalışsaydım adresi farklı old. silmezdi.(çünkü ben her new lediğimde o nesne için yeni bir
            //adres açmış oluyorum buraya da yeni  bir adresle product yollayacağım için o adreste bir yer bulamaz ve silemez....
        {
            Product productToDelete = null;
            //foreach (var item in _products)
            //{
            //    if(product.ProductId==item.ProductId)
            //        productToDelete=item;
            //}dizinin hepsini bu şekilde tek tek dolaşmak zorunda kaldık daha uzun bir kod...
            
            productToDelete =_products.SingleOrDefault(x=>x.ProductId==product.ProductId);
            _products.Remove(productToDelete);  
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _products.Where(x=>x.CategoryId==categoryId).ToList();
        }

        public List<ProductDetailsDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            var productToUpdate=_products.SingleOrDefault(x=>x.ProductId==product.ProductId);
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.UnitPrice=product.UnitPrice;
            productToUpdate.CategoryId=product.CategoryId;
            productToUpdate.UnitsInStock=product.UnitsInStock;

        }
    }
}
