using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotcakes.CommerceDTO;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.Commerce.Catalog;
using Hotcakes.Commerce.Marketing.PromotionQualifications;
using Hotcakes.CommerceDTO.v1.Contacts;
using Hotcakes.CommerceDTO.v1.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Raktárkezelő.Controllers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;

namespace Raktárkezelő
{
    public partial class Form1 : Form
    {
        private Api proxy;






        public Form1()
        {
            InitializeComponent();
            Proxy();

            

            SkuListazas();
        }

        private void Proxy()
        {
            var url = string.Empty;
            var key = string.Empty;

            if (url == string.Empty) url = "http://20.234.113.211:8096";
            if (key == string.Empty) key = "1-c5ef7982-7d10-4fd6-a506-27e3b01ddfb2";

            proxy = new Api(url, key);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

            SkuListazas();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Proxy();
            var sel_prod = proxy.ProductsFindBySku(listBox1.SelectedItem.ToString());

            var inventory = proxy.ProductInventoryFindForProduct(sel_prod.Content.Bvin).Content[0];
            label2.Text = inventory.QuantityOnHand.ToString();

            string skuText = sel_prod.Content.Sku.ToString();

            label7.Text = skuText;

            //Kép beállítása
            var imageName = sel_prod.Content.ImageFileMedium.ToString();


            string imageDirectory = "kepek/";


            string imagePath = System.IO.Path.Combine(imageDirectory, imageName);

            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                Image image = Image.FromFile(imagePath);
                pictureBox4.Image = image;
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Hiba történt a kép betöltésekor: " + ex.Message);
                Image image2 = Image.FromFile("kepek/alap.jpg");
                pictureBox4.Image = image2;
            }


        }




        private void button2_Click(object sender, EventArgs e)
        {
            Adatbevitel();

            RendelesHozzaadasa();

        }

        private void SkuListazas()
        {
            try
            {

                var response = proxy.ProductsFindAll();

                var product = response.Content;

                if (product != null)
                {
                    var sku = from x in product
                              where x.Sku != null && x.Sku.Contains(textBox1.Text)
                              select x.Sku;

                    if (sku.Any())
                    {
                        listBox1.DataSource = sku.ToList();
                        listBox1.DisplayMember = "Sku";
                    }
                    else
                    {
                        // Handle case where no matching SKU was found
                        MessageBox.Show("Nem található hozzá SKU.");
                    }
                }
                else
                {
                    // Handle case where product data is null
                    MessageBox.Show("Nem található termék adat");
                }
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                MessageBox.Show("Egy hiba lépett fel: " + ex.Message);
            }
        }

        private void RendelesHozzaadasa()
        {



            try
            {
                Proxy();

                int soldQuantity = int.Parse(textBox2.Text.ToString());
                var sel_prod = proxy.ProductsFindBySku(listBox1.SelectedItem.ToString());

                var inventory = proxy.ProductInventoryFindForProduct(sel_prod.Content.Bvin).Content[0];

                label2.Text = inventory.QuantityOnHand.ToString();
                inventory.QuantityOnHand -= soldQuantity;
                var response = proxy.ProductInventoryUpdate(inventory);

                if (response.Errors.Count == 0)
                {
                    string skuText = (listBox1.SelectedItem).ToString();
                    MessageBox.Show($"A(z) {skuText} SKU-jú termék készlete csökkent ennyivel: {soldQuantity}");

                    label2.Text = inventory.QuantityOnHand.ToString();

                }
                else
                {
                    MessageBox.Show("A mentés sikertelen!");
                    return;
                }
            }
            catch (Exception ex)
            {
                // Kezeletlen kivételek esetén
                MessageBox.Show($"Hiba történt a művelet közben: {ex.Message}");
            }
        }

        private void Adatbevitel()
        {
            var soldQuantity = textBox2.Text;
            var controller = new Controllers.SoldQuantityController();
            var modifyResponse = controller.ModifySoldQuantity(soldQuantity);

            if (modifyResponse)
            {
                //MessageBox.Show("Sikeres adatbevitel!");

                Form2 form = new Form2();
                if (form.ShowDialog() != DialogResult.OK) { return; }






            }
            else
            {
                MessageBox.Show("Nem sikerült az adatbevitel!");

                return;
            }

        }








    }
}
