using BusinessRulesEngine.Models;

namespace BusinessRulesEngine.Interface
{
    public interface IOrderProcessing
    {
        PaymentStatus ProcessOrder<T>(T model);
    }
}
