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

namespace Raktárkezelő
{
    public partial class Form1 : Form
    {
        private Api proxy;

        List<string> skuk = new List<string> { "AAA001", "AAA114", "AAA115", "AAA116", "AAA117", "AAA118", "AAA119", 
            "AAA120", "AAA121", "AAA122", "AAA123", "AAA124", "AAA125", "AAA126", "AAA127", "AAA128", "AAA129", "AAA130",
            "AAA131", "AAA132", "AAA133", "AAA134", "AAA135", "AAA136", "AAA137", "AAA138", "AAA139", "AAA140", "AAA141", 
            "AAA142", "AAA143", "AAA144", "AAA145", "AAA146", "AAA147", "AAA148", "AAA149", "AAA150", "AAA151", "AAA152", 
            "AAA153", "AAA154", "AAA155", "AAA156", "AAA157", "AAA158", "AAA159", "AAA160", "AAA161", "AAA162", "AAA163", 
            "AAA164", "AAA165", "AAA166", "AAA167", "AAA168", "AAA169", "AAA170", "AAA171", "AAA172", "AAA173", "AAA174", 
            "AAA175", "AAA176", "AAA177", "AAA178", "AAA179", "AAA180", "AAA181", "AAA182", "AAA183", "AAA184", "AAA185", 
            "AAA186", "AAA187", "AAA188", "AAA189", "AAA190", "AAA191", "AAA192", "AAA193", "AAA194", "AAA195", "AAA196", 
            "AAA197", "AAA198", "AAA199", "AAA200", "AAA201", "AAA202", "AAA203", "AAA204", "AAA205", "AAA206", "AAA207",
            "AAA208", "AAA209", "AAA210" };




        public Form1()
        {
            InitializeComponent();

            var url = string.Empty;
            var key = string.Empty;

            if (url == string.Empty) url = "http://20.234.113.211:8096";
            if (key == string.Empty) key = "1-c5ef7982-7d10-4fd6-a506-27e3b01ddfb2";

            proxy = new Api(url, key);

            var skuk2 = from x in skuk
                        where x.Contains(textBox1.Text) select x;

            listBox1.DataSource = skuk2.ToList();

            //try
            //{
            //    var response = proxy.ProductsFindAll();
            //    var product = response.Content;

            //    if (product != null)
            //    {
            //        var sku = from x in product
            //                  where x.Sku != null && x.Sku.Contains(textBox1.Text)
            //                  select x;

            //        if (sku.Any())
            //        {
            //        //listBox1.DataSource = skuk;
            //            listBox1.DataSource = sku.ToList();
            //            listBox1.DisplayMember = "Sku";
            //        }
            //        else
            //        {
            //            // Handle case where no matching SKU was found
            //            MessageBox.Show("No matching SKU found.");
            //        }
            //    }
            //    else
            //    {
            //        // Handle case where product data is null
            //        MessageBox.Show("No product data available.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Handle any other exceptions
            //    MessageBox.Show("An error occurred: " + ex.Message);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            


            Form2 form = new Form2();
            if (form.ShowDialog() != DialogResult.OK) { return; }

            try
            {
                int soldQuantity = int.Parse(textBox2.Text.ToString());
                string skuText = (listBox1.SelectedItem).ToString();
                MessageBox.Show($"A(z) {skuText} SKU-jú termék készlete csökkent ennyivel: {soldQuantity}");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hiba történt a művelet közben: {ex.Message}");
            }

            //try
            //{
            //    int soldQuantity = int.Parse(textBox2.Text.ToString());
            //    string termekId = (((Product)listBox1.SelectedItem).Id).ToString();
            //    string skuText = (((Product)listBox1.SelectedItem).Sku).ToString();
            //    var order = new OrderDTO();

            //    // add billing information
            //    order.BillingAddress = new AddressDTO
            //    {
            //        AddressType = AddressTypesDTO.Billing,
            //        City = "West Palm Beach",
            //        CountryBvin = "BF7389A2-9B21-4D33-B276-23C9C18EA0C0",
            //        FirstName = "John",
            //        LastName = "Dough",
            //        Line1 = "319 N. Clematis Street",
            //        Line2 = "Suite 500",
            //        Phone = "561-228-5319",
            //        PostalCode = "33401",
            //        RegionBvin = "7EBE4F07-A844-47B8-BDA8-863DDDF5C778"
            //    };

            //    // add at least one line item
            //    //order.Items = new List<LineItemDTO>();
            //    order.Items.Add(new LineItemDTO
            //    {
            //        ProductId = termekId,
            //        Quantity = soldQuantity
            //    });

            //    // add the shipping address
            //    order.ShippingAddress = new AddressDTO();
            //    order.ShippingAddress = order.BillingAddress;
            //    order.ShippingAddress.AddressType = AddressTypesDTO.Shipping;

            //    // specify who is creating the order
            //    order.UserEmail = "info@hotcakescommerce.com";
            //    order.UserID = "1";

            //    // call the API to create the order
            //    var response2 = proxy.OrdersCreate(order);
            //    if (response2.Errors.Count == 0)
            //    {
            //        // Sikeres mentés esetén
            //        MessageBox.Show($"A(z) {skuText} SKU-jú termék készlete csökkent ennyivel: {soldQuantity}");
            //    }
            //    else
            //    {
            //        // Sikertelen mentés esetén
            //        MessageBox.Show("Hiba a mentés során");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Kezeletlen kivételek esetén
            //    MessageBox.Show($"Hiba történt a művelet közben: {ex.Message}");
            //}

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var skuk2 = from x in skuk
                        where x.Contains(textBox1.Text)
                        select x;

            listBox1.DataSource = skuk2.ToList();

            //try
            //{
            //    var response = proxy.ProductsFindAll();
            //    var product = response.Content;

            //    if (product != null)
            //    {
            //        var sku = from x in product
            //                  where x.Sku != null && x.Sku.Contains(textBox1.Text)
            //                  select x;

            //        if (sku.Any())
            //        {
            //            listBox1.DataSource = sku.ToList();
            //            listBox1.DisplayMember = "Sku";
            //        }
            //        else
            //        {
            //            // Handle case where no matching SKU was found
            //            MessageBox.Show("No matching SKU found.");
            //        }
            //    }
            //    else
            //    {
            //        // Handle case where product data is null
            //        MessageBox.Show("No product data available.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Handle any other exceptions
            //    MessageBox.Show("An error occurred: " + ex.Message);
            //}
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string skuText = (((Product)listBox1.SelectedItem).Sku).ToString();
            string skuText = (listBox1.SelectedItem).ToString();
            label7.Text = skuText;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
