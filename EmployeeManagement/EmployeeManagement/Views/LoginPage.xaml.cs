using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeManagement.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
		    
		  //  LoginViewModel.DisplayPrompt += () => DisplayAlert(LoginViewModel.title, LoginViewModel.text, "ok");
		    InitializeComponent();


		}
	}
}