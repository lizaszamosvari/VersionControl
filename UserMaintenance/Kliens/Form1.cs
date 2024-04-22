using Hotcakes.Commerce.Catalog;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Contacts;
using Hotcakes.CommerceDTO.v1.Orders;

namespace Kliens
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

            Hotcakes.CommerceDTO.v1.ApiResponse<List<ProductDTO>> response3 = proxy.ProductsFindAll();
            var product = response3.Content;
            var sku = from x in product
                      where x.Sku.Contains(textBox1.Text)
                      select x;

            listBox1.DataSource = sku;
            listBox1.DisplayMember = "Sku";


        }


        private void button1_Click(object sender, EventArgs e)
        {
            string termekId = (((Product)listBox1.SelectedItem).Id).ToString();
            int soldQuantity = int.Parse(textBox2.Text.ToString());

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
            order.Items = new List<LineItemDTO>();
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
            Hotcakes.CommerceDTO.v1.ApiResponse<OrderDTO> response = proxy.OrdersCreate(order);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Hotcakes.CommerceDTO.v1.ApiResponse<List<ProductDTO>> response3 = proxy.ProductsFindAll();
            var product = response3.Content;
            var sku = from x in product
                      where x.Sku.Contains(textBox1.Text)
                      select x;

            listBox1.DataSource = sku;
            listBox1.DisplayMember = "Sku";
        }
    }
}