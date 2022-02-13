using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model.Blank;
using Vending.Model.DB;
using Vending.Repository;

namespace Vending.Controller
{
    internal class EditDrinkController
    {
        DrinkRepository DrinkRepository = new DrinkRepository();

        public void AddDrink(DrinkBlank drink)
        {
            DrinkRepository.AddDrink(new Drink()
            {
                Name = drink.Name,
                Cost = drink.Cost,
                Count = drink.Count,
                Image = drink.Image
            });
        }

        public void EditDrink(DrinkBlank drink)
        {
            DrinkRepository.EditDrink(new Drink()
            {
                Id = drink.Id,
                Cost = drink.Cost,
                Count = drink.Count,
                Image = drink.Image
            });
        }
    }
}
