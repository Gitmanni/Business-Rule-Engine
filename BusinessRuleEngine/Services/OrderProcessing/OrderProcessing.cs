using BusinessRulesEngine.Interface;
using BusinessRulesEngine.Models;

namespace BusinessRulesEngine.Services.OrderProcessing
{
    public abstract class OrderProcessing<TModel> : IOrderProcessing
    {
        public PaymentStatus ProcessOrder<T>(T model)
        {
            return ProcessOrder((TModel)(object)model);
        }

        protected abstract PaymentStatus ProcessOrder(TModel model);

    }
}
