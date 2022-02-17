using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
//SOLID prensipleri
/// <summary>
/// open closed principle
/// </summary>
namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal productDal;
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //magic strings
            if (product.ProductName.Length < 2)
                return new ErrorResult(Messages.ProductNameInvalid);
             productDal.Add(product);
            return new Result(true,Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour == 22)
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            return new SuccessDataResult<List<Product>>(productDal.GetAll(),"ürünler listelendi");
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(productDal.GetAll(p=>p.CategoryId == categoryId),"Yeteeeer jsjjsjsjs");
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(productDal.Get(p=>p.ProductId==id),"Ama gerçekten yeter jsjsjsjsjjs");   
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetaiils()
        {
             //Başarılıysa cınım(yukarıydakiler de aynı )
            return new SuccessDataResult<List<ProductDetailsDto>>(productDal.GetProductDetails(),"hadi bu da sondu jsjsjsjs");
        }
    }
}
