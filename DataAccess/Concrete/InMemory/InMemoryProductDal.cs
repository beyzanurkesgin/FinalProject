using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        private object productToDelet;
        private IEnumerable<object> _product;
        private Product productToDelete;
        private object product;
        private object productToUpdate;

        public InMemoryProductDal()
        {
            //Oracle,sql,Postgres,
            _products = new List<Product> {
             new Product{CategoryId=1 ,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
             new Product{CategoryId=1 ,ProductId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
             new Product{CategoryId=1 ,ProductId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
             new Product{CategoryId=1 ,ProductId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
             new Product{CategoryId=1 ,ProductId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
            
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }
            //LINQ -Languge Integrated Quarty (Dile Baağlı Sorgulama
            //Lambda
        public void Delete(Product product) 
        {
           
            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);


            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
          return  _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update (Product product)
        {
            //Gönderdiğim ürün id'sine sahip listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
