using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abc.MvcWeb.Entity;

namespace Abc.MvcWeb.Models
{
    public class Favori
    {
        public List<FavoriLine> _favoriLines = new List<FavoriLine>();

        public List<FavoriLine> FavoriLines
        {
            get { return _favoriLines; }
        }

        public void AddProduct(Product product, int quantity)
        {
            var line = _favoriLines.FirstOrDefault(i => i.Product.Id == product.Id);
            if (line == null)
            {
                _favoriLines.Add(new FavoriLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteProduct(Product product)
        {
            _favoriLines.RemoveAll(i => i.Product.Id == product.Id);
        }

        public double Total()
        {
            return _favoriLines.Sum(i => i.Product.Price * i.Quantity);
        }

        public void Clear()
        {
            _favoriLines.Clear();
        }
    }

    public class FavoriLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}