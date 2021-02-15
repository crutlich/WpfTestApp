using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp.Data
{
    class ProductService
    {

        SoftTradePlusDBEntities db;

        public ProductService()
        {
            db = new SoftTradePlusDBEntities();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> ProductList = new List<Product>();
            try
            {
                var SqlQuery = from obj in db.Products
                               select obj;
                foreach (var product in SqlQuery)
                {
                    ProductList.Add(new Product { Id_prod = product.Id_prod,
                                                  Name_prod = product.Name_prod, 
                                                  Price = product.Price, 
                                                  Type_prod = product.Type_prod,
                                                  TimeLimit = product.TimeLimit});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ProductList;
        }

        public bool Add(Product newProduct)
        {
            bool IsAdded = false;

            try
            {
                var product = new Product();

                product.Name_prod = newProduct.Name_prod;
                product.Price = newProduct.Price;
                product.Type_prod = newProduct.Type_prod;
                product.TimeLimit = newProduct.TimeLimit;


                db.Products.Add(product);
                var NoOfRowsAffected = db.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return IsAdded;
        }

        public bool Update(Product productBeforeUpdate)
        {
            bool IsUpdated = false;

            try
            {
                var newProduct = db.Products.Find(productBeforeUpdate.Id_prod);

                newProduct.Name_prod = productBeforeUpdate.Name_prod;
                newProduct.Price = productBeforeUpdate.Price;
                newProduct.Type_prod = productBeforeUpdate.Type_prod;
                newProduct.TimeLimit = productBeforeUpdate.TimeLimit;

               
                var NoOfRowsAffected = db.SaveChanges();

                IsUpdated = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsUpdated;
        }

        public bool Delete(Product productToDelete)
        {
            bool IsDeleted = false;
            try
            {
                var product = db.Products.Find(productToDelete.Id_prod);
                db.Products.Remove(product);

                var NoOfRowsAffected = db.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return IsDeleted;
        }

    }
}
