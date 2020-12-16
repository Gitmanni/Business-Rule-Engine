using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services.OrderProcessing;

namespace BusinessRulesEngine.Services.OrderProcessingService
{
    public class VideoService : OrderProcessing<VideoModel>
    {
        protected override PaymentStatus ProcessOrder(VideoModel model)
        {
            //****** Apply logic to add First Aid video to the packing slip
            if (!string.IsNullOrEmpty(model.Details))
            {
                return new PaymentStatus
                {
                    IsOrderProcessed = true,
                    Message = "Added First Aid video to the packing slip."
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
