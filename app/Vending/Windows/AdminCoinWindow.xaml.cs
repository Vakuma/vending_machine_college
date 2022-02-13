using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Vending.Controller;
using Vending.ViewModel;

namespace Vending.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminCoinWindow.xaml
    /// </summary>
    public partial class AdminCoinWindow : System.Windows.Window
    {
        CoinsController controller = new CoinsController();

        public AdminCoinWindow()
        {
            InitializeComponent();

            coin10.Text = controller.Coins.Where(x => x.Nominal == 10).FirstOrDefault().Count.ToString();
            coin5.Text = controller.Coins.Where(x => x.Nominal == 5).FirstOrDefault().Count.ToString();
            coin1.Text = controller.Coins.Where(x => x.Nominal == 1).FirstOrDefault().Count.ToString();
            coin2.Text = controller.Coins.Where(x => x.Nominal == 2).FirstOrDefault().Count.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            controller.Coins.Find(x => x.Nominal == 10).Count = Convert.ToInt32(coin10.Text);
            controller.Coins.Find(x => x.Nominal == 1).Count = Convert.ToInt32(coin1.Text);
            controller.Coins.Find(x => x.Nominal == 2).Count = Convert.ToInt32(coin2.Text);
            controller.Coins.Find(x => x.Nominal == 5).Count = Convert.ToInt32(coin5.Text);

            controller.EditCoin();

            Close();
        }

       
    }
}
