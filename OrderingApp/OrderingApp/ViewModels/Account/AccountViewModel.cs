using OrderingApp.Common.Models;
using OrderingApp.Models.Core.Customer;
using OrderingApp.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderingApp.ViewModels.Account
{
    public class AccountViewModel : ModelBase
    {
        Customer _current;
        public Customer Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged();
            }
        }
        string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
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
        string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        public AccountViewModel()
        {
            Login = new Command(OnLogin);

            var result = App.Customers.GetItemsAsync().Result;
            if(result.Count <= 0)
            {
                var CurrentCustomer = new Customer()
                {
                    CustomerID = "CT10001",
                    FirstName = "John Michael",
                    LastName = "Canete",
                    MiddleName = "De los Reyes",
                    BirthDate = new DateTime(1992, 11, 17),
                    BillingAddress = "Bahak Poblacion Lilo-an Cebu",
                    ShippingAddress = "Bahak Poblacion Lilo-an Cebu",
                    UserName = "jcanete",
                    Password = "canasta"
                };

                int affected = App.Customers.SaveItemAsync(CurrentCustomer).Result;

                if(affected <= 0)
                {
                    Application.Current.MainPage.DisplayAlert("Error Occured!", "Unable to save mock data!", "OK");
                }
            }
            
        }

        void OnLogin()
        {
            Current = App.Customers.GetUserInfo(Username, Password).Result;
            if (Current != null)
            {
                Application.Current.MainPage = new OrderingApp.Views.Core.MasterDetail();
            }
            else
            {
                Current = App.Customers.GetItemsAsync().Result.FirstOrDefault();

                Username = Current.UserName;
                Password = Current.Password;

                if(Current.UserName == Username && Current.Password == Password)
                {
                    Application.Current.MainPage = new OrderingApp.Views.Core.MasterDetail();
                }
                else
                {
                    ErrorMessage = "Invalid Username or Password!";
                }
            }
        }
        ICommand _login;
        public ICommand Login
        {
            get { return _login; }
            set {
                _login = value;
                OnPropertyChanged();
            }
        }
    }
}
