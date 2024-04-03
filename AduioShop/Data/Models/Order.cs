namespace AduioShop.Data.Models
{
    public class Order
    {
        /// <summary>
        /// OrderId
        /// </summary>
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string Adress { get; set; }
        public string status { get; set; }


    }
}
