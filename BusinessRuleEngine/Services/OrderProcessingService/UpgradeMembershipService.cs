using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services.OrderProcessing;
using BusinessRulesEngine.Utilites;

using System;
namespace BusinessRulesEngine.Services.OrderProcessingService
{
    public class UpgradeMembershipService : OrderProcessing<UpgradeMembershipModel>
    {
        protected override PaymentStatus ProcessOrder(UpgradeMembershipModel model)
        {
            //********* Logic for apply upgrade ********
            if (!string.IsNullOrEmpty(model.MembershipName))
            {
                model.UpgradeStartDate = DateTime.Now;
                model.UpgradeEndDate = DateTime.Now.AddYears(1);
                return new PaymentStatus
                {
                    IsOrderProcessed = true,
                    Message = "Membership upgraded"
                };
            }

            return new PaymentStatus
            {
                IsOrderProcessed = false,
                Message = PaymentOrderType.UpgradeMemebership
            }; ;

        }    
    }
}
