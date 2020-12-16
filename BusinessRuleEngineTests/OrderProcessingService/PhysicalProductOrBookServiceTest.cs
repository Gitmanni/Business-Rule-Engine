using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services.OrderProcessingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessRuleEngineTest.OrderProcessingService
{
    [TestClass]
    public class PhysicalProductOrBookServiceTest
    {
        PhysicalProductOrBookService physicalProductOrBookService;

        [TestInitialize]
        public void Init()
        {

            physicalProductOrBookService = new PhysicalProductOrBookService();
        }

        [TestMethod]
        public void ProcessOrder_Success_Test()
        {
            //************** Data ******************
            PhysicalProductOrBookModel model = new PhysicalProductOrBookModel() { AgentName = "M Kashyap", AgentCommission = 5 };
            //*************** Act ******************
            var result = physicalProductOrBookService.ProcessOrder<PhysicalProductOrBookModel>(model);
            //************** Assert ****************
            Assert.IsTrue(result.IsOrderProcessed);
            Assert.AreEqual("Commission payment is generated to the agent", result.Message);

        }

        [TestMethod]
        public void ProcessOrder_BookName_Empty_Test()
        {
            //************** Data ******************
            PhysicalProductOrBookModel model = new PhysicalProductOrBookModel() { AgentCommission = 5 };
            //*************** Act ******************
            var result = physicalProductOrBookService.ProcessOrder<PhysicalProductOrBookModel>(model);
            //************** Assert ****************
            Assert.IsFalse(result.IsOrderProcessed);
        }
    }
}
