

namespace SAP_MAGENTO.Controllers.MagentoControllers
{
    public static class ProductController
    {
        public static RouteGroupBuilder ProductEndpoint(this RouteGroupBuilder app)
        {
            app.MapGet("/item", () =>
            {                   
                return Results.Ok();  

            }).WithName("Get-Product-Magento")
              .WithOpenApi();


            return app;
        }
    }
}