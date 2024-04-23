using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raktárkezelő.Controllers
{
    public class SoldQuantityController
    {
        public bool ModifySoldQuantity(string quantity)
        {
            try
            {
                


                if (!ValidateQuantity(quantity.ToString()))
                {
                    MessageBox.Show("Érvénytelen darabszám. Ne adj meg negatív, nullával kezdődő vagy nem egész értékeket");
                    return false;
                }
                return true;

            }
            catch (Exception err)
            {
                MessageBox.Show($"Nem sikerült a módosítás: {err.Message}");
                //throw;
                return false;
            }


        }

        public bool ValidateQuantity(string quantity)
        {
            Regex regex = new Regex(@"^(0|[1-9]\d*)$");
            return regex.IsMatch(quantity);
        }
    }
}
