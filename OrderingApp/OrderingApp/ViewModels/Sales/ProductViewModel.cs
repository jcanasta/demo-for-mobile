using OrderingApp.Common.Models;
using OrderingApp.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderingApp.ViewModels.Sales
{
    public class ProductViewModel : ModelBase
    {
        List<Product> _products;
        public List<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        Product _selectedItem;
        public Product SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public ProductViewModel()
        {
            var products = App.Products.GetItemsAsync().Result;
            if(products.Count <= 0)
            {
                Products = new List<Product>()
                {
                    new Product(){ ProductID = "P1001", ProductName="Product 1", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png",  CategoryName="Category 1", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1002", ProductName="Product 2", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png",  CategoryName="Category 1", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1003", ProductName="Product 3", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png",  CategoryName="Category 1", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1004", ProductName="Product 4", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png", CategoryName="Category 2", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1005", ProductName="Product 5", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png",  CategoryName="Category 2", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1006", ProductName="Product 6", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png", CategoryName="Category 2", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1007", ProductName="Product 1", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png",  CategoryName="Category 1", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1008", ProductName="Product 2", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png",  CategoryName="Category 1", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1009", ProductName="Product 3", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png",  CategoryName="Category 1", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1010", ProductName="Product 4", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png", CategoryName="Category 2", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1011", ProductName="Product 5", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png",  CategoryName="Category 2", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1012", ProductName="Product 6", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png", CategoryName="Category 2", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1013", ProductName="Product 1", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png",  CategoryName="Category 1", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1014", ProductName="Product 2", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png",  CategoryName="Category 1", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1015", ProductName="Product 3", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png",  CategoryName="Category 1", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1016", ProductName="Product 4", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png", CategoryName="Category 2", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1017", ProductName="Product 5", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png",  CategoryName="Category 2", ProductPrice=100, IsOutOfStock = false },
                    new Product(){ ProductID = "P1018", ProductName="Product 6", Description="The quick brown foxs jumps over the lazy dog. The quick brown foxs jumps over the lazy dog.", Image="https://www.cicis.com/media/1176/pizza_trad_pepperonibeef.png", CategoryName="Category 2", ProductPrice=100, IsOutOfStock = false }
                };
                App.Products.SaveAllItem(Products);
            }
            else
            {
                Products = App.Products.GetItemsAsync().Result;
            }
            
        }
    }
}
