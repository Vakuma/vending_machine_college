using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model.DB;
using Vending.Repository;

namespace Vending.Controller
{
    internal class CoinsController
    {   
        CoinsRepository repository = new CoinsRepository();

        public List<Coin> Coins { get; set; }

        public CoinsController()
        {
            Coins = repository.GetCoin().ToList();
        }

        public void EditCoin()
        {
            repository.EditCoinsCount(Coins);
        }
    }
}
