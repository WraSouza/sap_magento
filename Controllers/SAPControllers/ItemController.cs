using SAP_MAGENTO.Models.SAPModels;

namespace SAP_MAGENTO.Controllers.SAPControllers
{
    public static class ItemController
    {
        public static RouteGroupBuilder ItemEndpoint(this RouteGroupBuilder app)
        {
            app.MapGet("/item", () =>
            {                   
                   return Results.Ok();  

            }).Produces<ItemSAP>(statusCode: StatusCodes.Status200OK)
              .Produces<ItemSAP>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-Item-SAP")
              .WithOpenApi();


            return app;
        }
    }
}