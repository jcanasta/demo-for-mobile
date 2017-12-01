using OrderingApp.Common.Models;
using OrderingApp.Models.Sales;
using OrderingApp.Models.Sales.Common;
using OrderingApp.Views.Pages.Sales.Ordering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderingApp.ViewModels.Sales
{
    public class ProductDetailViewModel : ModelBase
    {
        Product _product;
        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged();
            }
        }
        string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        public ProductDetailViewModel(Product product)
        {
            Product = product;
            Title = product.ProductName;
            AddToCart = new Command(OnAddToCart);
        }

        private void OnAddToCart()
        {
            
            var customer = App.Customers.GetItemsAsync().Result.FirstOrDefault();
            var existingOrder = App.Orders.GetItemsAsync().Result.Where(c => c.IsDone == false && c.CustomerID == customer.CustomerID).FirstOrDefault();
            if (existingOrder != null)
            {
                var order = new OrderDetail()
                {
                    OrderID = existingOrder.OrderID,
                    ProductID = Product.ProductID,
                    ProductName = Product.ProductName,
                    ProductPrice = Product.ProductPrice,
                    Quantity = 1,
                    Total = Product.ProductPrice
                };
                var existingOrderProduct = App.OrderDetails.GetItemsAsync().Result.Where(c=> c.OrderID == existingOrder.OrderID && c.ProductID == order.ProductID).FirstOrDefault();
                if(existingOrderProduct != null)
                {
                    existingOrderProduct.Quantity = existingOrderProduct.Quantity + order.Quantity;
                    existingOrderProduct.Total = order.ProductPrice * existingOrderProduct.Quantity;

                    
                    int affected = App.OrderDetails.SaveItemAsync(existingOrderProduct).Result;
                    if (affected > 0)
                    {
                        existingOrder.Total = App.OrderDetails.GetItemsAsync().Result.AsEnumerable().Sum(c => c.Total);

                        int result = App.Orders.SaveItemAsync(existingOrder).Result;
                        if (result > 0)
                        {
                            Application.Current.MainPage.DisplayAlert("Order Updates", "Order Successfully Updated!", "OK");
                        }
                        else
                        {
                            Application.Current.MainPage.DisplayAlert("Failed", "Unable to Update the item to 'My Orders'", "OK");
                        }
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Failed", "Unable to Update the item to 'My Orders'", "OK");
                    }
                   
                }
                else
                {
                    

                    int affected = App.OrderDetails.SaveItemAsync(order).Result;
                    if (affected > 0)
                    {
                        existingOrder.Total = App.OrderDetails.GetItemsAsync().Result.AsEnumerable().Sum(c => c.Total);

                        int result = App.Orders.SaveItemAsync(existingOrder).Result;
                        if (result > 0)
                        {
                            Application.Current.MainPage.DisplayAlert("Order Updates", "Order Successfully Added!", "OK");
                        }
                        else
                        {
                            Application.Current.MainPage.DisplayAlert("Failed", "Unable to Add the item to 'My Orders'", "OK");
                        }
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Failed", "Unable to Add the item to 'My Orders'", "OK");
                    }
                }
            }
            else
            {
                var top = App.Orders.MaxOrderID().Result;
                int _assignOrderID = 1;
                if(top != null)
                {
                    _assignOrderID = top.OrderID + 1;
                }
                
                var orderdet = new OrderDetail()
                {
                    OrderID = _assignOrderID,
                    ProductID = Product.ProductID,
                    ProductName = Product.ProductName,
                    ProductPrice = Product.ProductPrice,
                    Quantity = 1,
                    Total = Product.ProductPrice
                };
                var order = new Order()
                {
                    OrderID = _assignOrderID,
                    CustomerID = customer.CustomerID,
                    CustomerName = customer.FirstName + " " + customer.LastName,
                    DateCreated = DateTime.Now,
                    Total = orderdet.Total,
                    IsDone = false
                };

                int result = App.Orders.SaveItemAsync(order).Result;
                if(result > 0)
                {
                    int affected = App.OrderDetails.SaveItemAsync(orderdet).Result;

                    if (affected > 0)
                    {
                        Application.Current.MainPage.DisplayAlert("Order Updates", "Order Successfully Added!", "OK");
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Failed", "Unable to Add the item to 'My Orders'", "OK");
                    }
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Failed", "Unable to Add the item to 'My Orders'", "OK");
                }
               
            }
        }

        ICommand _addToCart;
        public ICommand AddToCart
        {
            get { return _addToCart; }
            set
            {
                _addToCart = value;
                OnPropertyChanged();
            }
        }

    }
}
