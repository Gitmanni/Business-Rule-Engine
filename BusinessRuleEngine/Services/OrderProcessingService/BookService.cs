using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services.OrderProcessing;


namespace BusinessRulesEngine.Services.OrderProcessingService
{
    public class BookService : OrderProcessing<BookModel>
    {
        protected override PaymentStatus ProcessOrder(BookModel bookModel)
        {
            //********* logic for Royalty calculation ********************
            bookModel.RoyaltyAmount = (bookModel.Quantity * bookModel.Price) + bookModel.Commission;

            if (!string.IsNullOrEmpty(bookModel.BookName))
            {
                return new PaymentStatus
                {
                    IsOrderProcessed = true,
                    Message = "Royalty slip created with Amount - " + bookModel.RoyaltyAmount,
                    IsNotificationSent = true
                };
            }

            return new PaymentStatus { IsOrderProcessed = false, Message = "No Royalty" }; ;
        }
    }
}
