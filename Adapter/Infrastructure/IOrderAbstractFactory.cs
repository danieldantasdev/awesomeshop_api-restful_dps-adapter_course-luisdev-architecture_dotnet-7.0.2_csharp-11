using Adapter.Core.Enums;
using Adapter.Infrastructure.Deliveries;
using Adapter.Infrastructure.Payments;

namespace Adapter.Infrastructure;

public interface IOrderAbstractFactory
{
    IPaymentService GetPaymentService(PaymentMethod method);
    IDeliveryService GetDeliveryService();
}