using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services.OrderProcessingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace BusinessRuleEngineTest.OrderProcessingService
{
    [TestClass]
    public class UpgradeMembershipServiceTest
    {
        UpgradeMembershipService upgradeMembershipService;

        [TestInitialize]
        public void Init()
        {
            upgradeMembershipService = new UpgradeMembershipService();
        }
        [TestMethod]
        public void ProcessOrder_Success_Test()
        {
            //************** Data ******************
            UpgradeMembershipModel model = new UpgradeMembershipModel() { MembershipName = "Study", UpgradeStartDate = DateTime.Today, UpgradeEndDate = DateTime.Today.AddDays(365) };
            //*************** Act ******************
            var result = upgradeMembershipService.ProcessOrder<UpgradeMembershipModel>(model);
            //************** Assert ****************
            Assert.IsTrue(result.IsOrderProcessed);
            Assert.AreEqual("Membership upgraded", result.Message);
        }

        [TestMethod]
        public void ProcessOrder_BookName_Empty_Test()
        {
            //************** Data ******************
            UpgradeMembershipModel model = new UpgradeMembershipModel() { MembershipName = "", UpgradeStartDate = DateTime.Today, UpgradeEndDate = DateTime.Today.AddDays(365) };
            //*************** Act ******************
            var result = upgradeMembershipService.ProcessOrder<UpgradeMembershipModel>(model);
            //************** Assert ****************
            Assert.IsFalse(result.IsOrderProcessed);
        }
    }
}
