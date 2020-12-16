using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services.OrderProcessingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessRuleEngineTest.OrderProcessingService
{
    [TestClass]
    public class VideoServiceTest
    {
        VideoService videoService;
        [TestInitialize]
        public void Init()
        {
            videoService = new VideoService();
        }
        [TestMethod]
        public void ProcessOrder_Success_Test()
        {
            //************** Data ******************
            VideoModel model = new VideoModel() { Details = "First Aid video to the packing slip", PackingDate = DateTime.Today };
            //*************** Act ******************
            var result = videoService.ProcessOrder<VideoModel>(model);
            //************** Assert ****************
            Assert.IsTrue(result.IsOrderProcessed);
            Assert.AreEqual("Added First Aid video to the packing slip.", result.Message);
        }

        [TestMethod]
        public void ProcessOrder_BookName_Empty_Test()
        {
            //************** Data ******************
            VideoModel model = new VideoModel() { Details = "", PackingDate = DateTime.Today };
            //*************** Act ******************
            var result = videoService.ProcessOrder<VideoModel>(model);
            //************** Assert ****************
            Assert.IsFalse(result.IsOrderProcessed);
        }
    }
}
