using OrderingApp.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderingApp.Views.Pages.Sales.Booking
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cart : ContentPage
	{
		public Cart ()
		{
			InitializeComponent ();
            BindingContext = new OrdersViewModel();
		}
	}
}