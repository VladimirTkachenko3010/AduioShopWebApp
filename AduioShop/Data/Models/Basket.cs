namespace AudioShop.Data.Models
{
    public class Basket
    {
        /// <summary>
        /// KorzinaId
        /// </summary>
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Info { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
    }
}
