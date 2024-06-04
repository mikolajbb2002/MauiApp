namespace BeerOrder;
    public partial class MainPage : ContentPage
    {
        public static List<string> Cart { get; private set; } = new List<string>();
        private int quantity = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnIncreaseQuantityButtonClicked(object sender, EventArgs e)
        {
            quantity++;
            quantityLabel.Text = quantity.ToString();
            quantityLabel1.Text = quantity.ToString();
        }

        private void OnDecreaseQuantityButtonClicked(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                quantityLabel.Text = quantity.ToString();
                quantityLabel1.Text = quantity.ToString();
            }
        }

        private void OnAddToCartButtonClicked(object sender, EventArgs e)
        {
            var selectedBeer = beerListView.SelectedItem as string;
            var selectedsnack = snackListView.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedBeer))
            {
                DisplayAlert("Błąd", "Proszę wybrać piwo.", "OK");
                return;
            }
            Cart.Add($"{selectedsnack} -{quantity} szt.");
            Cart.Add($"{selectedBeer} - {quantity} szt.");
            statusLabel.Text = $"{selectedBeer} {selectedsnack} dodane do koszyka.";
        }

        private async void OnGoToCartButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }
    }


