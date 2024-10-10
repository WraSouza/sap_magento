using MediatR;
using SAP_MAGENTO.Mediator.Queries.SAPQueries.GetAllItems;
using SAP_MAGENTO.Mediator.Queries.SAPQueries.GetItemById;
using SAP_MAGENTO.Models.SAPModels;

namespace SAP_MAGENTO.Controllers.SAPControllers
{
    public static class ItemController
    {
        public static RouteGroupBuilder ItemEndpoint(this RouteGroupBuilder app)
        {
            app.MapGet("/item", async (IMediator mediator) =>
            {      
                var allItens = new GetAllItemsQuery(); 

                var itensInSAP = await mediator.Send(allItens);

                return Results.Ok(itensInSAP);  

            }).Produces<ItemSAP>(statusCode: StatusCodes.Status200OK)
              .Produces<ItemSAP>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-Item-SAP")
              .WithOpenApi();

              app.MapGet("/item/{id}", async (int id,IMediator mediator) =>
            {      
                var itemById = new GetItemByIdQuery(id.ToString()); 

                var itensInSAP = await mediator.Send(itemById);

                return Results.Ok(itensInSAP);  

            }).Produces<ItemSAP>(statusCode: StatusCodes.Status200OK)
              .Produces<ItemSAP>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-ItemById-SAP")
              .WithOpenApi();


            return app;
        }
    }
}