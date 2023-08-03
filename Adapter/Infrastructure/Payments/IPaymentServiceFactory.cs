using Adapter.Core.Enums;

namespace Adapter.Infrastructure.Payments;

public interface IPaymentServiceFactory
{
    IPaymentService GetService(PaymentMethod paymentMethod);
}