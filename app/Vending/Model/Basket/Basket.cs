using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model.Blank;

namespace Vending.Model.Bucket
{
    class Basket
    { 
        
       public List<DrinkBlank> SelectDrinks { get; set;  }
       public List<int> Coins { get; set; }
       public int AddingUserMoney { get; set; }

       public int Change { get; set; }

        public Basket() {

            SelectDrinks = new List<DrinkBlank>();
            Coins = new List<int>();
            AddingUserMoney = 0;
            Change = 0;
       }

        public void AddCoin(int nominal) {

            AddingUserMoney += nominal;
            Change = AddingUserMoney;
            Coins.Add(nominal);
        }

       public int SelectDrink(int idDrink, int cost) {

            var drink = SelectDrinks.Find(x => x.Id == idDrink);

            if (drink != null)
            {
                SelectDrinks.Find(x => x.Id == idDrink).Count += 1;
            }
            else
            {
                SelectDrinks.Add(new DrinkBlank()
                {
                    Id = idDrink,
                    Count = 1,
                    Cost = cost
                });
            }

            Change -= cost;

            return Change;
       }
    }
}
