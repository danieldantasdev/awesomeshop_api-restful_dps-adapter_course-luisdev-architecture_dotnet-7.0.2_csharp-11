using Adapter.Application.Models;
using Adapter.Infrastructure;
using Adapter.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IPaymentServiceFactory _paymentServiceFactory;

    public OrdersController(
        IPaymentServiceFactory paymentServiceFactory)
    {
        _paymentServiceFactory = paymentServiceFactory;
    }

    [HttpPost]
    public IActionResult Post(
        [FromServices] InternationalOrderAbstractFactory internationalOrderAbstractFactory,
        [FromServices] NationalOrderAbstractFactory nationalOrderAbstractFactory,
        OrderInputModel model
    )
    {
        IOrderAbstractFactory orderAbstractFactory;

        if (model.IsInternational != null && model.IsInternational.Value)
            orderAbstractFactory = internationalOrderAbstractFactory;
        else
            orderAbstractFactory = nationalOrderAbstractFactory;

        var paymentResult = orderAbstractFactory
            .GetPaymentService(model.PaymentInfo.PaymentMethod)
            .Process(model);

        orderAbstractFactory
            .GetDeliveryService()
            .Deliver(model);

        return NoContent();
    }
}