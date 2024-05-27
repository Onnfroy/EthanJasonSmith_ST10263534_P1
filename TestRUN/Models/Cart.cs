using System.Collections.Generic;
using System.Linq;

namespace CLDV6211_POE_P1.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddProduct(Product product)
        {
            var existingItem = Items.Find(i => i.Product.ProductId == product.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                Items.Add(new CartItem { Product = product, Quantity = 1 });
            }
        }

        public void RemoveProduct(Product product)
        {
            var existingItem = Items.Find(i => i.Product.ProductId == product.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity--;
                if (existingItem.Quantity <= 0)
                {
                    Items.Remove(existingItem);
                }
            }
        }

        public decimal GetTotal()
        {
            return Items.Sum(i => i.Product.Price * i.Quantity);
        }

        internal void RemoveProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}

