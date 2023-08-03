using Adapter.Application.Models;
using Adapter.Infrastructure.Payments.Adapters;

namespace Adapter.Infrastructure.Payments;

public class PaymentSlipService : IPaymentService
{
    private readonly IExternalPaymentSlipService _externalService;

    public PaymentSlipService(IExternalPaymentSlipService externalService)
    {
        _externalService = externalService;
    }

    public object Process(OrderInputModel model)
    {
        var paymentSlipServiceAdapter = new PaymentSlipServiceAdapter(_externalService);

        var paymentSlipModel = paymentSlipServiceAdapter.GeneratePaymentSlip(model);

        return "Dados do Boleto";
    }
}