using OrderingApp.Common.Models;
using OrderingApp.Models.Core.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp.ViewModels.Core
{
    public class CustomerViewModel : ModelBase
    {
        Customer _currentCustomer;
        public Customer CurrentCustomer
        {
            get { return _currentCustomer; }
            set
            {
                _currentCustomer = value;
                OnPropertyChanged();
            }
        }
        public CustomerViewModel()
        {
            CurrentCustomer = App.Customers.GetItemsAsync().Result.FirstOrDefault();
        }
    }
}
