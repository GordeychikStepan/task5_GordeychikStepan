using System;
using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;
using Xamarin.Forms.Xaml;

namespace СreditСalculator
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new FirstPage();
			MainPage = new NavigationPage(new FirstPage())
			{
				BarBackgroundColor = Color.FromHex("#2F2F2F"),
				BarTextColor = Color.White,
			};

		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
