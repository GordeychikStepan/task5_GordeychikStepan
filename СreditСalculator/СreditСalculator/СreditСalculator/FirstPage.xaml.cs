using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace СreditСalculator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FirstPage : ContentPage
	{
		public FirstPage ()
		{
			InitializeComponent();
		}

		private async void InputButton_Clicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(userNameEntry.Text) || string.IsNullOrEmpty(passwordEntry.Text))
			{
				DisplayAlert("Внимание", "Заполните логин и пароль", "OK");
				return;
			}

			await Navigation.PushAsync(new MainPage(userNameEntry.Text, passwordEntry.Text));
		}
	}
}