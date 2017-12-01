using OrderingApp.Common.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp.Models.Sales
{
    public class Product : ModelBase
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

        string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
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
        string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                OnPropertyChanged();
            }
        }
        bool _isOutOfStock;
        public bool IsOutOfStock
        {
            get { return _isOutOfStock; }
            set
            {
                _isOutOfStock = value;
                OnPropertyChanged();
            }
        }
    }
}
