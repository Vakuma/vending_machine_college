using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model.Blank;
using Vending.Model.Bucket;
using Vending.Model.DB;
using Vending.Repository;
using Vending.Utils;

namespace Vending.ViewModel
{
    class DrinkController
    {
        
        private DrinkRepository DrinkRepository = new DrinkRepository();
        private CoinsRepository CoinsRepository = new CoinsRepository();

        public Basket userBasket = new Basket();
        public List<DrinkBlank> Drink = new List<DrinkBlank>();

        public DrinkController()
        {
            foreach (var item in DrinkRepository.GetDrink())
            {
                Drink.Add(new DrinkBlank()
                {
                    Id = item.Id,
                    Cost = item.Cost,
                    Image = item.Image,
                    Name = item.Name,
                    IsCanBuy = false,
                    Count = item.Count,
                    ImageBitmap = item.Image.ByteArrayToImage()
            });
            }
        }
        public void SelectDrink(int idDrink)
        {
            var selectedDrink = Drink.Find(x => x.Id == idDrink);

            if (selectedDrink.Count >= 1)
            {
                userBasket.SelectDrink(selectedDrink.Id, selectedDrink.Cost);
                Drink.Find(x => x.Id == idDrink).Count -= 1;
            }

            Validate();
        }
        public int AddCoin(int nominal)
        {
            userBasket.AddCoin(nominal);
            Validate();
            return userBasket.AddingUserMoney;
        }
        public void OnGetChange()
        {
            var coin1 = userBasket.Coins.Where(x => x == 1).Count();
            var coin2 = userBasket.Coins.Where(x => x == 2).Count();
            var coin5 = userBasket.Coins.Where(x => x == 5).Count();
            var coin10 = userBasket.Coins.Where(x => x == 10).Count();

            var Coin = CoinsRepository.GetCoin();

            Coin.Find(x => x.Nominal == 1).Count += coin1;
            Coin.Find(x => x.Nominal == 2).Count += coin2;
            Coin.Find(x => x.Nominal == 5).Count += coin5;
            Coin.Find(x => x.Nominal == 10).Count += coin10;

            CoinsRepository.EditCoinsCount(Coin);

            Drink.ForEach(x => DrinkRepository.EditDrinkCount(x.Id, x.Count));
        }

        private void Validate()
        {
            foreach (var item in Drink)
            {
                if (item.Cost <= userBasket.Change 
                    && item.Count != 0)
                {
                    item.IsCanBuy = true;
                }
                else
                {
                    item.IsCanBuy = false;
                }
            }
        }


        public void OnClear()
        {
            userBasket = new Basket();
            Drink.ForEach(x => x.IsCanBuy = false);
        }
    }
}
