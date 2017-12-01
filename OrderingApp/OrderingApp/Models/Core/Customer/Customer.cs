using OrderingApp.Models.Core.Common;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp.Models.Core.Customer
{
    public class Customer : Person
    {
        int _id;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        string _customerID;
        public string CustomerID
        {
            get { return _customerID; }
            set
            {
                _customerID = value;
                OnPropertyChanged();
            }
        }
        string _billingAddress;
        public string BillingAddress
        {
            get { return _billingAddress; }
            set
            {
                _billingAddress = value;
                OnPropertyChanged();
            }
        }
        string _shippingAddress;
        public string ShippingAddress
        {
            get { return _shippingAddress; }
            set
            {
                _shippingAddress = value;
                OnPropertyChanged();
            }
        }

        string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                _companyName = value;
                OnPropertyChanged();
            }
        }
        string _username;
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }
        string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }
}
