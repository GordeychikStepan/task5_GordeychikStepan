using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace СreditСalculator
{
	public partial class MainPage : TabbedPage
	{
		string userLogin;
		string userPassword;
		double value;

		public MainPage(string userLogin, string userPassword)
		{
			InitializeComponent();

			typeOfPaymentPicker.Items.Add("Аннуитетный");
			typeOfPaymentPicker.Items.Add("Дифференцированный");
			typeOfPaymentPicker.Items.Add("Ежекв-ый/ежегодный");

			nowDatePicker.Date = DateTime.Now;

			this.userLogin = userLogin;
			this.userPassword = userPassword;

			helloLabel.Text = $"Доброго времени суток, {userLogin}!";
		}

		private void InterestRateSlider_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			value = e.NewValue;
			percentLabel.Text = $"{value:F1}%";
		}

		private void CalculateButton_Clicked(object sender, EventArgs e)
		{
			double sumCredit = 0;
			int termMonths = 0;

			if (!double.TryParse(sumCreditEntry.Text, out sumCredit)) { return; }
			if (!int.TryParse(termMounthEntry.Text, out termMonths)) { return; }

			string typeOfPayment = typeOfPaymentPicker.SelectedItem.ToString();

			if (typeOfPayment == "Аннуитетный")
			{
				// Расчет аннуитетного платежа
				double monthlyPayment = CalculateAnnuityPayment(sumCredit, termMonths, value);
				double totalAmount = monthlyPayment * termMonths;
				double overpayment = totalAmount - sumCredit;

				monthlyPaymentLabel.Text = monthlyPayment.ToString("F2");
				totalAmountLabel.Text = totalAmount.ToString("F2");
				overpaymentLabel.Text = overpayment.ToString("F2");
			}
			else
			{
				double monthlyPayment = CalculateAnnuityPayment(sumCredit, termMonths, value);
				double totalAmount = monthlyPayment * termMonths;
				double overpayment = totalAmount - sumCredit;

				monthlyPaymentLabel.Text = "...";
				totalAmountLabel.Text = totalAmount.ToString("F2");
				overpaymentLabel.Text = overpayment.ToString("F2");
			}
		}

		private double CalculateAnnuityPayment(double sumCredit, int termMonths, double value)
		{
			double monthlyRate = value / 100 / 12;
			double denominator = Math.Pow(1 + monthlyRate, termMonths) - 1;
			double annuityPayment = sumCredit * monthlyRate * Math.Pow(1 + monthlyRate, termMonths) / denominator;
			return annuityPayment;
		}

	}
}
