using MediatR;
using SAP_MAGENTO.Models.SAPModels;

namespace SAP_MAGENTO.Controllers.SAPControllers
{
    public static class BusinessPartnerController
    {
        public static RouteGroupBuilder BusinessPartnerEndpoint(this RouteGroupBuilder app)
        {
            app.MapGet("/businesspartner", () =>
            {                   
                   return Results.Ok();  

            }).Produces<BusinessPartnerSAP>(statusCode: StatusCodes.Status200OK)
              .Produces<BusinessPartnerSAP>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-BusinessPartner-SAP")
              .WithOpenApi();

            app.MapPost("/businesspartner", (IMediator mediator) =>
            {      
                //var createNewBPInSAP = new SAPBusinessPartnerCommand();

                //var orders = await mediator.Send(createNewBPInSAP);          
                return Results.Ok();  

            }).Produces<BusinessPartnerSAP>(statusCode: StatusCodes.Status200OK)
              .Produces<BusinessPartnerSAP>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Post-BusinessPartner-SAP")
              .WithOpenApi();

           

            return app;
        }
    }
}