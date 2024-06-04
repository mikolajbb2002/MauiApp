using Microsoft.Maui.Controls;

namespace BeerOrder
{
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
            cartListView.ItemsSource = MainPage.Cart;
        }

        private async void OnPlaceOrderButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderPage());
        }
    }
}