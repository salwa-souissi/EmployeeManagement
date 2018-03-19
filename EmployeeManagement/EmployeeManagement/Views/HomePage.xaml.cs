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
       
	    #region Metho d for expandable list

	      private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var product = e.Item as Employee;
	        var vm = BindingContext as HomeViewModel;
	        vm.ShowOrHideEmployees(product);
	    }

	    #endregion
      
        #region Serachbar Method
	    private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        var vm = this.BindingContext as HomeViewModel;
	        if (string.IsNullOrEmpty(e.NewTextValue))
	        {
	            list.ItemsSource = vm._employeeList;
	        }
	        else
	        {
	            list.ItemsSource = vm._employeeList.Where(x => x.Name.ToLower().Contains(e.NewTextValue.ToLower()));
	        }
	    }
        #endregion

    }
}