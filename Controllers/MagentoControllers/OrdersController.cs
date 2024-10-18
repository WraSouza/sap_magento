

using MediatR;
using SAP_MAGENTO.Mediator.Queries.MagentoQueries.GetAllOrders;

namespace SAP_MAGENTO.Controllers.MagentoControllers
{
    public static class OrdersController
    {
        public static RouteGroupBuilder OrderEndpoint(this RouteGroupBuilder app)
        {
            app.MapGet("/orders", async (IMediator mediator) =>
            {   
                var orders = new GetAllOrdersQuery();

                var allOrders = await mediator.Send(orders);

                return Results.Ok(allOrders);  

            }).WithName("Get-Orders-Magento")
              .WithOpenApi();


            return app;
        }
    }
}