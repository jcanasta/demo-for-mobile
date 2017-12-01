using OrderingApp.Common.Models;
using OrderingApp.Models.Sales.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp.ViewModels.Sales
{
    public class OrdersViewModel : ModelBase
    {
        public OrdersViewModel()
        {
            var cust = App.Customers.GetItemsAsync().Result.FirstOrDefault();
            var orders = App.Orders.GetItemsAsync().Result.FirstOrDefault(c => c.IsDone == false && c.CustomerID == cust.CustomerID);
            Orders = orders;
            OrderDetails = App.OrderDetails.GetItemsAsync().Result.Where(c => c.OrderID == Orders.OrderID).ToList();
        }
        Order _orders;
        public Order Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }
        List<OrderDetail> _orderdetails;
        public List<OrderDetail> OrderDetails
        {
            get { return _orderdetails; }
            set
            {
                _orderdetails = value;
                OnPropertyChanged();
            }
        }
    }
}
