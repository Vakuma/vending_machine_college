using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model.DB;

namespace Vending.Repository
{
    internal class CoinsRepository
    {
        VendingMachineEntities db = new VendingMachineEntities();

        public List<Coin> GetCoin()
        {

            return db.Coin.ToList();
        }

        public void EditCoinsCount(List<Coin> Coin)
        {
            foreach (var item in Coin)
            {
                db.Coin.Find(item.Id).Count = item.Count;
            }

            db.SaveChanges();
        }

    }
}
