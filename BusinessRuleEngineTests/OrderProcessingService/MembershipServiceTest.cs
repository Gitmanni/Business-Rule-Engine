using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services.OrderProcessingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessRuleEngineTest.OrderProcessingService
{
    [TestClass]
    public class MembershipServiceTest
    {
        MembershipService membershipService;

        [TestInitialize]
        public void Init()
        {
            membershipService = new MembershipService();
        }

        [TestMethod]
        public void ProcessOrder_Success_Test()
        {
            //************** Data ******************
            MembershipModel model = new MembershipModel()
            {
                MembershipName = "Maer",
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today
            };
            //*************** Act ******************
            var result = membershipService.ProcessOrder<MembershipModel>(model);
            //************** Assert ****************
            Assert.IsTrue(result.IsOrderProcessed);
            Assert.AreEqual("Membership Activated", result.Message);
        }

        [TestMethod]
        public void ProcessOrder_BookName_Empty_Test()
        {
            //************** Data ******************
            MembershipModel model = new MembershipModel()
            {
                MembershipName = "",
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today
            };
            //*************** Act ******************
            var result = membershipService.ProcessOrder<MembershipModel>(model);
            //************** Assert ****************
            Assert.IsFalse(result.IsOrderProcessed);
        }
    }
}
