using OrderingApp.Models.Sales;
using OrderingApp.ViewModels.Sales;
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
	public partial class ProductDetail : ContentPage
	{
		public ProductDetail (Product product)
		{
			InitializeComponent ();
            BindingContext = new ProductDetailViewModel(product);
		}
	}
}