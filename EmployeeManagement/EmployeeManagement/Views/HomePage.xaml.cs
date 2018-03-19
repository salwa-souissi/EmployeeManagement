using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeManagement.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
		  
            InitializeComponent();
		}

	    #region OnAppearing Method

	     protected override void OnAppearing()
        {

            var vm = this.BindingContext as HomeViewModel;
            vm.GetData();
            list.ItemsSource = vm.EmployeeList;
            base.OnAppearing();

            }


	    #endregion
       
	    #region Method for expandable list

	      private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var employee = e.Item as Employee;
	        var vm = BindingContext as HomeViewModel;
	        vm.ShowOrHideEmployees(employee);
	    }

	    #endregion
      
     

    }
}