using System;
using System.Windows;
using System.Windows.Controls;
using Vending.ViewModel;
using Vending.Window;

namespace Vending
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        DrinkController controller = new DrinkController();
        
        public MainWindow()
        {
            InitializeComponent();

            DrinkList.ItemsSource = controller.Drink;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var buttonTag = Convert.ToInt32((sender as Button).Tag);
            controller.SelectDrink(buttonTag);
            buttonNominal1.IsEnabled = false;
            buttonNominal2.IsEnabled = false;
            buttonNominal5.IsEnabled = false;
            buttonNominal10.IsEnabled = false;
            buttonChange.IsEnabled = true;

            changeText.Text = $"Сдача: {controller.userBasket.Change} руб.";

            UpdateLists();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var buttonTag = Convert.ToInt32((sender as Button).Tag);
            var allMoney = controller.AddCoin(buttonTag);
            money.Text = $"{allMoney} руб.";
            UpdateLists();
        }

        private void UpdateLists()
        {
            DrinkList.ItemsSource = null;
            DrinkList.ItemsSource = controller.Drink;
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            controller.OnGetChange();
            Clear();
        }

        private void Clear()
        {
            buttonNominal1.IsEnabled = true;
            buttonNominal2.IsEnabled = true;
            buttonNominal5.IsEnabled = true;
            buttonNominal10.IsEnabled = true;
            buttonChange.IsEnabled = false;
            controller.OnClear();
            UpdateLists();
            money.Text = $"0 руб.";
            changeText.Text = $"Сдача:";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.ShowDialog();
        }
    }
}
