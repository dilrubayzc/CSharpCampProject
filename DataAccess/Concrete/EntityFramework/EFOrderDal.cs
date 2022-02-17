using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    //IProductDal'ın kalmasının sebebi ilerde ben sadece product'a özel methodlar yazabilirim
    public class EFOrderDal:EfEntityRepositoryBase<Order,NorthwindDbContext>,IOrderDal
    {
    }
}
