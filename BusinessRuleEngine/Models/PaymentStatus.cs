

namespace BusinessRulesEngine.Models
{
    public class PaymentStatus
    {
        public string Message { get; set; }
        public bool IsOrderProcessed { get; set; }
        public bool IsNotificationSent { get; set; }
    }
}
