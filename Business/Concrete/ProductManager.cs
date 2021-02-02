using Business.Abstract;

using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;
using Product = Entities.Concrete.Product;
using DataAccess.Abstract;

namespace Business.Concrete
{
     public class ProductManager:IProductServise
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
         _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İşkodları
            //Yetkisi var mı?
            return _productDal.GetAll();

        }
    }
}
