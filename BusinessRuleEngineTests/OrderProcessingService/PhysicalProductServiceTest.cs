using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services.OrderProcessingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessRuleEngineTest.OrderProcessingService
{
    [TestClass]
    public class PhysicalProductServiceTest
    {
        PhysicalProductService physicalProductService;
        [TestInitialize]
        public void Init()
        {
            physicalProductService = new PhysicalProductService();
        }
        [TestMethod]
        public void ProcessOrder_Success_Test()
        {
            //************** Data ******************
            PhysicalProductModel model = new PhysicalProductModel() { Name = "Books", Description = "Packed" };
            //*************** Act ******************
            var result = physicalProductService.ProcessOrder<PhysicalProductModel>(model);
            //************** Assert ****************
            Assert.IsTrue(result.IsOrderProcessed);
            Assert.AreEqual("Packing slip created for physical product", result.Message);
        }

        [TestMethod]
        public void ProcessOrder_BookName_Empty_Test()
        {
            //************** Data ******************
            PhysicalProductModel model = new PhysicalProductModel() { Name = "", Description = "Packed" };
            //*************** Act ******************
            var result = physicalProductService.ProcessOrder<PhysicalProductModel>(model);
            //************** Assert ****************
            Assert.IsFalse(result.IsOrderProcessed);
        }
    }
}
