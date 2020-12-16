using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services.OrderProcessing;
using BusinessRulesEngine.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Services.OrderProcessingService
{
    public class MembershipService : OrderProcessing<MembershipModel>
    {
        protected override PaymentStatus ProcessOrder(MembershipModel membershipModel)
        {
            //******* If Payment is done then activate the membership and sent a mail to user.
            if (!string.IsNullOrEmpty(membershipModel.MembershipName))
            {
                membershipModel.Status = true;
                return new PaymentStatus
                {
                    IsOrderProcessed = true,
                    Message = "Membership Activated",
                    IsNotificationSent = true
                };
            }
            return new PaymentStatus
            {
                IsOrderProcessed = false,
                Message = "Membership Not Activated",
                IsNotificationSent = false
            };
        }
    }
}
