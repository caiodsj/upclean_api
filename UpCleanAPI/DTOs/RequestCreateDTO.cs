﻿namespace UpCleanAPI.DTOs
{
    public class RequestCreateDTO
    {
        public int IdClient { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime DeliveryDateTime { get; set; }
        public List<AmountService> Services { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
