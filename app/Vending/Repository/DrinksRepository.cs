using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model.DB;

namespace Vending.Repository
{
    class DrinkRepository
    {
        VendingMachineEntities db = new VendingMachineEntities();

        public List<Drink> GetDrink() {

            return db.Drink.ToList();
        }

        public void AddDrink(Drink drink)
        {
            db.Drink.Add(drink);
            db.SaveChanges();
        }

        public void EditDrinkCount(int id, int count)
        {
            db.Drink.Find(id).Count = count;
            db.SaveChanges();
        }
        public void EditDrink(Drink drink)
        {
            db.Drink.Find(drink.Id).Cost = drink.Cost;
            db.Drink.Find(drink.Id).Image = drink.Image;
            db.Drink.Find(drink.Id).Count = drink.Count;
            db.SaveChanges();
        }
    }
}
