using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Vending.Controller;
using Vending.Model.Blank;
using Vending.Utils;

namespace Vending.Window
{
    /// <summary>
    /// Логика взаимодействия для EditDrink.xaml
    /// </summary>
    public partial class EditDrink : System.Windows.Window
    {

        EditDrinkController controller = new EditDrinkController();

        OpenFileDialog openFileDialog = new OpenFileDialog();

        byte[] file = null;
        
        DrinkBlank item = null;

        public EditDrink()
        {
            InitializeComponent();

            saveButton.Click += saveAddButtonClick;
        }

        public EditDrink(DrinkBlank item)
        {
            InitializeComponent();

            image.Source = item.Image.ByteArrayToImage();
            costTextBox.Text = item.Cost.ToString();
            countTextBox.Text = item.Count.ToString();

            saveButton.Click += saveEditButtonClick;

            this.item = item;
        }

        private void addPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                addPhotoButton.Content = filename;

                file = File.ReadAllBytes(filename);
            }
        }
        private void saveAddButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.AddDrink(new DrinkBlank()
                {
                    Count = Convert.ToInt32(countTextBox.Text),
                    Cost = Convert.ToInt32(costTextBox.Text),
                    Image = file,
                });
                Close();
            }
            catch 
            {

            }
        }

        private void saveEditButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.EditDrink(new DrinkBlank()
                {
                    Id = item.Id,
                    Count = Convert.ToInt32(countTextBox.Text),
                    Cost = Convert.ToInt32(costTextBox.Text),
                    Image = file == null ? item.Image : file,
                });
                Close();
            }
            catch
            {

            }
        }

    }
}
