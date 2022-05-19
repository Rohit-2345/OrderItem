namespace OrderItem.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }   
    }
}
