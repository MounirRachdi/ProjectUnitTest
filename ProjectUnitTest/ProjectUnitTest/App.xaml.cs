using ProjectUnitTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ProjectUnitTest
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //MainPage = new ProjectUnitTest.MainPage();
            var model = DependencyInject<ProductViewModel>.Get();
            model.CurrentPage = DependencyInject<MainPage>.Get();
            model.CurrentPage.BindingContext = model;
            var nav = new NavigationPage(model.CurrentPage);
            model._nav = nav.Navigation;
            MainPage = nav;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
