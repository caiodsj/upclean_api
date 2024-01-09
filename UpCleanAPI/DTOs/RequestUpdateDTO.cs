namespace UpCleanAPI.DTOs
{
    public class RequestUpdateDTO
    {
        public DateTime DeliveryDateTime { get; set; }
        public List<AmountService> Services { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
