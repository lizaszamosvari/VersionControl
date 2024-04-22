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

namespace Raktárkezelő
{
    public partial class Form1 : Form
    {
        private Api proxy;

        public Form1()
        {
            InitializeComponent();

            var url = string.Empty;
            var key = string.Empty;

            if (url == string.Empty) url = "http://20.234.113.211:8096";
            if (key == string.Empty) key = "1-c5ef7982-7d10-4fd6-a506-27e3b01ddfb2";

            proxy = new Api(url, key);

            try
            {
                var response = proxy.ProductsFindAll();
                var product = response.Content;

                if (product != null)
                {
                    var sku = from x in product
                              where x.Sku != null && x.Sku.Contains(textBox1.Text)
                              select x;

                    if (sku.Any())
                    {
                        listBox1.DataSource = sku.ToList();
                        listBox1.DisplayMember = "Sku";
                    }
                    else
                    {
                        // Handle case where no matching SKU was found
                        MessageBox.Show("No matching SKU found.");
                    }
                }
                else
                {
                    // Handle case where product data is null
                    MessageBox.Show("No product data available.");
                }
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int soldQuantity = int.Parse(textBox2.Text.ToString());
            string termekId = (((Product)listBox1.SelectedItem).Id).ToString();


            Form2 form = new Form2();
            if (form.ShowDialog() != DialogResult.OK) { return; }
            var order = new OrderDTO();

            // add billing information
            order.BillingAddress = new AddressDTO
            {
                AddressType = AddressTypesDTO.Billing,
                City = "West Palm Beach",
                CountryBvin = "BF7389A2-9B21-4D33-B276-23C9C18EA0C0",
                FirstName = "John",
                LastName = "Dough",
                Line1 = "319 N. Clematis Street",
                Line2 = "Suite 500",
                Phone = "561-228-5319",
                PostalCode = "33401",
                RegionBvin = "7EBE4F07-A844-47B8-BDA8-863DDDF5C778"
            };

            // add at least one line item
            //order.Items = new List<LineItemDTO>();
            order.Items.Add(new LineItemDTO
            {
                ProductId = termekId,
                Quantity = soldQuantity
            });

            // add the shipping address
            order.ShippingAddress = new AddressDTO();
            order.ShippingAddress = order.BillingAddress;
            order.ShippingAddress.AddressType = AddressTypesDTO.Shipping;

            // specify who is creating the order
            order.UserEmail = "info@hotcakescommerce.com";
            order.UserID = "1";

            // call the API to create the order
            var response2 = proxy.OrdersCreate(order);
            if (response2.Errors.Count > 0)
            {
                MessageBox.Show("Order created successfully!");
            }
            else
            {
                MessageBox.Show("Failed to create order: ");
            }
        }
    }
}
