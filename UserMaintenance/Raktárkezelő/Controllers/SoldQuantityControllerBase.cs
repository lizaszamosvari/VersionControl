using System;

namespace Raktárkezelő.Controllers
{
    public class SoldQuantityControllerBase
    {
        public bool ModifySoldQuantity(string quantity)
        {
            try
            {
                if (!ValidateDesc(Desc))
                {
                    MessageBox.Show("Érvénytelen leírás: Nagybetűvel kezdődő, ponttal végződő, legalább 50 karakteres leírást adj meg!");
                    return false;
                }


                if (!ValidatePrice(Price.ToString()))
                {
                    MessageBox.Show("Érvénytelen ár. Ne adj meg negatív, nullával kezdődő vagy nem egész értékeket");
                    return false;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show($"Nem sikerült a módosítás: {err.Message}");
                //throw;
            }
        }
    }
}