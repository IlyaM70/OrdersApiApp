namespace OrdersApiAppSPD011.Model.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product()
        {
            Name = "";
            Quantity = 0;
            Price = 0;
        }
    }
}
