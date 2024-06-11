using System;
using System.IO;
using Microsoft.Maui.Controls;
using BeerOrder.Models;


namespace BeerOrder
{
    public partial class OrderPage : ContentPage
    {
        private Database _database;

        public OrderPage()
        {
            InitializeComponent();

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Orders.db3");
            _database = new Database(dbPath);
        }

        private void OnSubmitOrderButtonClicked(object sender, EventArgs e)
        {
            var name = nameEntry.Text;
            var surname = surnameEntry.Text;
            var street = streetEntry.Text;
            var city = cityEntry.Text;
            var postalCode = postalCodeEntry.Text;
            var phone = phoneEntry.Text;

            var order = new Models.BeerOrder()
            {
                name = name,
                surname = surname,
                street = street,
                city = city,
                postalcode = postalCode,
                phone = phone
            };

            int result = _database.SaveOrder(order);

            if (result != -1)
            {
                confirmationLabel.Text = "Zamówienie zostało zapisane pomyślnie!";
            }
            else
            {
                confirmationLabel.Text = "Błąd podczas zapisywania zamówienia.";
            }
        }
    }
}