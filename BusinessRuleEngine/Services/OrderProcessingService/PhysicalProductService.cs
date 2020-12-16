using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services.OrderProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessRulesEngine.Services.OrderProcessingService
{
    public class PhysicalProductService : OrderProcessing<PhysicalProductModel>
    {
        protected override PaymentStatus ProcessOrder(PhysicalProductModel model)
        {
            //*********** Logic for packing slip **********
            if (!string.IsNullOrEmpty(model.Name))
            {
                return new PaymentStatus
                {
                    IsOrderProcessed = true,
                    Message = "Packing slip created for physical product",
                };
            }
            return new PaymentStatus
            {
                IsOrderProcessed = false,
                Message = ""
            }; ;
        }
    }
}
