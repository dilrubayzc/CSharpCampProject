using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidations;
using Core.Aspects.Autofac.Validations;
using Core.CrossCuttingConcerns.Validations;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context);
            //if (!result.IsValid)
            //    throw new ValidationException(result.Errors);
            //magic strings
            /*ValidationTool.Validate(new ProductValidator(), product);*///ilerde daha da güzel olacak...
                                                                         // bir kategoride en fazla 10 ürün olabilir 
            var result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckProductNameExists(product.ProductName));
            if (result != null)
                return result;
            productDal.Add(product);
            return new Result(true, Messages.ProductAdded);
            //if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            //{
            //    if (CheckProductNameExists(product.ProductName).Success)
            //    {
            //        productDal.Add(product);
            //        return new Result(true, Messages.ProductAdded);
            //    }
            //}
            //return new ErrorResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour == 23)
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            return new SuccessDataResult<List<Product>>(productDal.GetAll(), "ürünler listelendi");
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(productDal.GetAll(p => p.CategoryId == categoryId), "Yeteeeer jsjjsjsjs");
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(productDal.Get(p => p.ProductId == id), "Ama gerçekten yeter jsjsjsjsjjs");
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetaiils()
        {
            //Başarılıysa cınım(yukarıydakiler de aynı )
            return new SuccessDataResult<List<ProductDetailsDto>>(productDal.GetProductDetails(), "hadi bu da sondu jsjsjsjs");
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //select count(*) from Product where categoryId=1;
            var result = productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 30)
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            return new SuccessResult();
        }
        private IResult CheckProductNameExists(string productName)
        {
            var result = productDal.Get(p => p.ProductName == productName);
            if (result ==null)
                return new SuccessResult();
            return new ErrorResult(Messages.ProductNameIsAlreadyExist);
            
        }
    }
}
