using System;

namespace BusinessRulesEngine.Models
{
    public class UpgradeMembershipModel
    {
        public string MembershipName { get; set; }
        public DateTime UpgradeStartDate { get; set; }
        public DateTime UpgradeEndDate { get; set; }
        public Boolean Status { get; set; }
    }
}
