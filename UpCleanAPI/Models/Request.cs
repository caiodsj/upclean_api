namespace UpCleanAPI.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime DeliveryDateTime { get; set; }
        public List<AmountService> Services { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
