using System;
using System.Collections.Generic;
//if you read this you ang at MAHre gay for worki
namespace WindowsFormsApp1.Model
{
    [Serializable]
    public class Type
    {
        public string Name { get; set; }
        public List<Product> products;

        public Type(string name)
        {
            this.Name = name;
            this.products = new List<Product>();
        }

        public Type()
        {
            this.Name = "";
            this.products = new List<Product>();
        }

        /// <summary>
        /// Retrieves the product specified by the position in the product list.
        /// </summary>
        /// <param name="index">The position the wanted product has in the product list.</param>
        /// <returns>The product at the position in the product list specified by the index.</returns>
        public Product GetProductByIndex(int index)
        {
            return products[index];
        }

        /// <summary>
        /// Retrieves the list of products. 
        /// </summary>
        /// <returns>A list of products that belongs to a type.</returns>
        public List<Product> GetProducts()
        {
            return products;
        }

        /// <summary>
        /// Adds a product to the list of products.
        /// </summary>
        /// <param name="productToAdd">The product to add.</param>
        public void AddProduct(Product productToAdd)
        {
            products.Add(productToAdd);
        }

        /// <summary>
        /// Removes an accessory from the list of accessories if the specified accessory exists in the list.
        /// </summary>
        /// <param name="productToRemove">The product to remove.</param>
        /// <returns>True if the specified product exists in the product list, otherwise false.</returns>
        public Boolean RemoveProduct(Product productToRemove)
        {
            if (products.Contains(productToRemove))
            {
                products.Remove(productToRemove);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes a product from the list of products.
        /// </summary>
        /// <param name = "index">The index of the product in the product list that should be removed..</param>
        public void RemoveProductByIndex(int index)
        {
            products.RemoveAt(index);
        }
    }
}
