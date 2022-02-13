
using System.Windows;
using Vending.Windows;

namespace Vending.Window
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : System.Windows.Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void buttonCoins_Click(object sender, RoutedEventArgs e)
        {
            AdminCoinWindow window = new AdminCoinWindow();
            window.ShowDialog();
        }

        private void buttonDrink_Click(object sender, RoutedEventArgs e)
        {
            AdminDrinkWindow window = new AdminDrinkWindow();
            window.ShowDialog();
        }
    }
}
