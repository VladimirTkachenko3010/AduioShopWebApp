namespace AudioShop.Data.Models
{
    public class User
    {
        /// <summary>
        /// UserId
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        private string Password { get; set; } = string.Empty;
    }
}
