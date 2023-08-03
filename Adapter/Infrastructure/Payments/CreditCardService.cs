using Adapter.Application.Models;

namespace Adapter.Infrastructure.Payments;

public class CreditCardService : IPaymentService
{
    public object Process(OrderInputModel model)
    {
        return "Transação aprovada";
    }
}