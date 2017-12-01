using OrderingApp.Models.Sales;
using OrderingApp.ViewModels.Sales;
using Syncfusion.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderingApp.Views.Pages.Sales.Ordering
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Products : ContentPage
    {
        public Products()
        {
            InitializeComponent();
            BindingContext = new ProductViewModel();

            listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "CategoryName",
            });
        }

        private void listView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var result = e.ItemData as Product;
            this.Navigation.PushAsync(new ProductDetail(result));
        }
    }
}