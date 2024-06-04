using System;
using BeerOrder;
using Microsoft.Maui.Controls;

namespace BeerOrder
{
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private async void OnSubmitOrderButtonClicked(object sender, EventArgs e)
        {
            var street = streetEntry.Text;
            var city = cityEntry.Text;
            var postalCode = postalCodeEntry.Text;
            var phone = phoneEntry.Text;

            if (string.IsNullOrEmpty(street) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(postalCode) || string.IsNullOrEmpty(phone))
            {
                await DisplayAlert("Błąd", "Proszę wypełnić wszystkie pola adresowe.", "OK");
                return;
            }

            // Tutaj można dodać logikę do przetwarzania zamówienia (np. wysyłanie zamówienia do serwera)
            MainPage.Cart.Clear();
            confirmationLabel.Text = "Dziękujemy za zamówienie! Twoje piwo zostanie dostarczone na wskazany adres.";
        }
    }
}