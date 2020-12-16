using System;


namespace BusinessRulesEngine.Models
{
    public class MembershipModel
    {
        public string MembershipName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean Status { get; set; }
    }
}
