using Adapter.Application.Models;

namespace Adapter.Infrastructure.Deliveries;

public interface IDeliveryService
{
    void Deliver(OrderInputModel model);
}