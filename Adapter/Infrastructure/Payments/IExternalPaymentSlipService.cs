using Adapter.Application.Models;
using Adapter.Infrastructure.Payments.Models;

namespace Adapter.Infrastructure.Payments;

public interface IExternalPaymentSlipService
{
    ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model);
}