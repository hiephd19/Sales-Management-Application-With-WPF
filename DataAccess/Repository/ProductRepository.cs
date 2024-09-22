using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void CreateProduct(Product newProduct)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                context.Products.Add(newProduct);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting product: " + ex.Message);
            }
        }
        public List<Product> GetAllProduct()
        {
            try
            {
                using var context = new Prn221FstoreContext();
                return context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting all product: " + ex.Message);
            }
        }
        public void UpdateProduct(Product updatedProduct)
        {
            try
            {
                using var context = new Prn221FstoreContext();

                Product? existingProduct = context.Products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId)
                    ?? throw new Exception("Product not found!");
                existingProduct.ProductName = updatedProduct.ProductName;
                existingProduct.Weight = updatedProduct.Weight;
                existingProduct.UnitPrice = updatedProduct.UnitPrice;
                existingProduct.UnitsInStock = updatedProduct.UnitsInStock;
                existingProduct.CategoryId = updatedProduct.CategoryId;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating product: " + ex.Message);
            }
        }
        public void DeleteProduct(int id)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                Product? deleteProduct = context.Products.FirstOrDefault(p => p.ProductId == id) ?? throw new Exception("Product not found!");
                context.Products.Remove(deleteProduct);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting product: " + ex.Message);
            }
        }
        public List<Product> SearchProductsByName(string productName)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                var searchResults = context.Products
                    .Where(p => p.ProductName.Contains(productName))
                    .ToList();
                return searchResults;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while searching for product: " + ex.Message);
            }
        }
        public Product? SearchProductsById(int id)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                Product? product = context.Products.FirstOrDefault(p => p.ProductId == id);
                return product ?? throw new Exception("Product not found!");
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching product by ID: " + ex.Message);
            }
        }
        public List<Product> SearchProductsByPrice(decimal minPrice, decimal maxPrice)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                var products = context.Products
                    .Where(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice)
                    .ToList();

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while searching products by price: " + ex.Message);
            }
        }

    }
}
