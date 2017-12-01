using OrderingApp.Common.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp.Models.Sales.Common
{
    public class OrderDetail : ModelBase
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
        int _orderID;
        public int OrderID
        {
            get { return _orderID; }
            set
            {
                _orderID = value;
                OnPropertyChanged();
            }
        }
        string _productID;
        public string ProductID
        {
            get { return _productID; }
            set
            {
                _productID = value;
                OnPropertyChanged();
            }
        }

        string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                OnPropertyChanged();
            }
        }

        decimal _productPrice;
        public decimal ProductPrice
        {
            get { return _productPrice; }
            set
            {
                _productPrice = value;
                OnPropertyChanged();
            }
        }
        int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }
        decimal _total;
        public decimal Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged();
            }
        }
        bool _isCancelled;
        public bool IsCancelled
        {
            get { return _isCancelled; }
            set
            {
                _isCancelled = value;
                OnPropertyChanged();
            }
        }
    }
}
