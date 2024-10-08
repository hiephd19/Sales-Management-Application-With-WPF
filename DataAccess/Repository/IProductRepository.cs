﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        public void CreateProduct(Product newProduct);
        public void UpdateProduct(Product updatedProduct);
        public List<Product> GetAllProduct();
        public List<Product> GetProductsByName(string productName);
        public void DeleteProduct(int id);        
        public Product? GetProductsById(int id);        
    }
}
