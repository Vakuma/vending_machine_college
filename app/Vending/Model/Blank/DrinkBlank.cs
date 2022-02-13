
using System.Windows.Media.Imaging;

namespace Vending.Model.Blank
{
    public class DrinkBlank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public BitmapImage ImageBitmap { get; set; }
        public int Cost { get; set; }
        public bool IsCanBuy { get; set; }
        public int Count { get; set; }
    }
}
