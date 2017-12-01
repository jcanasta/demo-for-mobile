using OrderingApp.Data;
using OrderingApp.Interface;
using OrderingApp.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace OrderingApp
{
    public partial class App : Application
    {
        static CustomerDB _customers;
        static ProductDB _products;
        static OrderDetailDB _ordersdetails;
        static OrderDB _orders;
        
        public App()
        {
            InitializeComponent();

            MainPage = new OrderingApp.Views.Pages.Account.Login()
            {
                BindingContext = new AccountViewModel()
            };

            OnLogin();

            
        }
        void OnLogin()
        {
            var Current = Customers.GetItemsAsync().Result.FirstOrDefault();
            if(Current != null)
            {
                MainPage = new OrderingApp.Views.Core.MasterDetail();
            }
        }

        public static CustomerDB Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new CustomerDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("OrderingDB.db3"));
                }
                return _customers;
            }
        }
        public static ProductDB Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("OrderingDB.db3"));
                }
                return _products;
            }
        }

        public static OrderDetailDB OrderDetails
        {
            get
            {
                if (_ordersdetails == null)
                {
                    _ordersdetails = new OrderDetailDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("OrderingDB.db3"));
                }
                return _ordersdetails;
            }
        }
        public static OrderDB Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new OrderDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("OrderingDB.db3"));
                }
                return _orders;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
