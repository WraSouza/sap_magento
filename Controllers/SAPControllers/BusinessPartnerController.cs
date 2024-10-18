using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP_MAGENTO.Mediator.Queries.SAPQueries.GetBPById;
using SAP_MAGENTO.Models.SAPModels;
using static SAP_MAGENTO.Models.SAPModels.BusinessPartnerSAP;

namespace SAP_MAGENTO.Controllers.SAPControllers
{
    public static class BusinessPartnerController
    {
        public static RouteGroupBuilder BusinessPartnerEndpoint(this RouteGroupBuilder app)
        {
            app.MapGet("/businesspartner", async (IMediator mediator) =>
            {                   
                   var businessPartner = new GetBPByIdQuery();

                    var newBusinessPartner = await mediator.Send(businessPartner);

                   return Results.Ok();  

            }).Produces<SAPBusinessPartner>(statusCode: StatusCodes.Status200OK)
              .Produces<SAPBusinessPartner>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-BusinessPartner-SAP")
              .WithOpenApi();

               app.MapPost("/businesspartner-sap", async (IMediator mediator, [FromBody] BusinessPartnerRequest business) =>
            {                   
                   var businessPartner = new GetBPByIdQuery(business.CPF);

                    var newBusinessPartner = await mediator.Send(businessPartner);

                   return Results.Ok();  

            }).Produces<BusinessPartnerSAP>(statusCode: StatusCodes.Status200OK)
              .Produces<BusinessPartnerSAP>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-BusinessPartner By Id-SAP")
              .WithOpenApi();

            app.MapPost("/businesspartner/", (IMediator mediator) =>
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