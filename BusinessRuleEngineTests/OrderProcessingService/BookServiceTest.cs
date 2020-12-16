using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services.OrderProcessingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessRuleEngineTest.OrderProcessingService
{
    [TestClass]
    public class BookServiceTest
    {
        BookService bookService;
        [TestInitialize]
        public void Init()
        {
            bookService = new BookService();
        }
        [TestMethod]
        public void ProcessOrder_Success_Test()
        {
            //***********Data ***********
            BookModel model = new BookModel() { BookName = "English", Price = 220, Quantity = 5, Commission = 10 };
            double royaltyAmount = (model.Price * model.Quantity) + model.Commission;
            string message = "Royalty slip created with Amount - " + royaltyAmount;
            //*****Calling method************
            var result = bookService.ProcessOrder<BookModel>(model);
            //************** Assert ****************
            Assert.IsTrue(result.IsOrderProcessed);
            Assert.AreEqual(message, result.Message);
        }

        [TestMethod]
        public void ProcessOrder_BookName_Empty_Test()
        {
            //***********Data pepration***********
            BookModel model = new BookModel() { BookName = "", Price = 220, Quantity = 5 };
            //*****Calling method************
            var result = bookService.ProcessOrder<BookModel>(model);
            //************** Assert ****************
            Assert.IsFalse(result.IsOrderProcessed);
        }
    }
}

