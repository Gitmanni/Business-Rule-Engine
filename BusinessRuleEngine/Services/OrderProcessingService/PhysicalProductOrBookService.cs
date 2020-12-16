using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services.OrderProcessing;

namespace BusinessRulesEngine.Services.OrderProcessingService
{
    public class PhysicalProductOrBookService : OrderProcessing<PhysicalProductOrBookModel>
    {
        protected override PaymentStatus ProcessOrder(PhysicalProductOrBookModel model)
        {
            //******* Logic for commission payment to the agent ********
            if (!string.IsNullOrEmpty(model.AgentName))
            {
                return new PaymentStatus
                {
                    IsOrderProcessed = true,
                    Message = "Commission payment is generated to the agent"
                };
            }
            return new PaymentStatus
            {
                IsOrderProcessed = false,
                Message = string.Empty
            }; ;
        }
    }
}
