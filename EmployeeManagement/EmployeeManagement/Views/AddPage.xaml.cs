﻿using System;
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
	public partial class AddPage : ContentPage
	{
		public AddPage ()
		{
            //AddViewModel addvm = new AddViewModel(this.Navigation);
            //this.BindingContext = addvm;
            //addvm.DisplayPrompt += () => DisplayAlert(addvm.title, addvm.text, "ok");
            InitializeComponent();
		}
	}
}