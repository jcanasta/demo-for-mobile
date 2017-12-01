using OrderingApp.Common.Models;
using OrderingApp.Models.Core.MasterFiles;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderingApp.Views.Core
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailMaster : ContentPage
    {
        public SfListView ListView;

        public MasterDetailMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailMasterViewModel();

            ListView = MenuItemsListView;
        }

        class MasterDetailMasterViewModel : ModelBase
        {
            public ObservableCollection<MenuItems> MenuItems { get; set; }

            public MasterDetailMasterViewModel()
            {
                MenuItems = new ObservableCollection<MenuItems>(new[]
                {
                    new MenuItems { Id = 0, Title = "My Account",  TargetType= typeof(Views.Pages.Core.Customer.Account) },
                    new MenuItems { Id = 1, Title = "My Orders", TargetType=typeof(Views.Pages.Sales.Booking.Cart) },
                    new MenuItems { Id = 1, Title = "Browse Products", TargetType=typeof(Views.Pages.Sales.Ordering.Products) }
                });
            }

          
        }
    }
}