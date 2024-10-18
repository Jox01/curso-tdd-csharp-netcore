using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArgentRose
{
    public class Inventory
    {
        private List<Product> _products = new List<Product>();

        public void Update()
        {
            foreach (var product in _products)
            {
                UpdateRegular(product);
            }
        }

        private void UpdateRegular(Product product)
        {
            product.Sellin -= 1;
            product.Quality -= 2;
        }

        public override string ToString()
        {
            return string.Join(" ", _products);
        }

        protected bool Equals(Inventory other)
        {
            return _products.SequenceEqual(other._products);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Inventory)obj);
        }

        public override int GetHashCode()
        {
            return (_products != null ? _products.GetHashCode() : 0);
        }

        public void AddProduct(Product product)
        {
            this._products.Add(product);
        }
    }

    public class Product
    {
        public string Description { get; set; }
        public int Quality { get; set; }
        public int Sellin { get; set; }

        public Product(string description, int quality, int sellin)
        {
            Description = description;
            Quality = quality;
            Sellin = sellin;
        }

        protected bool Equals(Product other)
        {
            return Description == other.Description && Quality == other.Quality && Sellin == other.Sellin;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Product)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Description, Quality, Sellin);
        }

        public override string ToString()
        {
            return $"{nameof(Description)}: {Description}, {nameof(Quality)}: {Quality}, {nameof(Sellin)}: {Sellin}";
        }
    }
}