using MediatR;
using Microsoft.AspNetCore.Mvc;
using SAP_MAGENTO.Mediator.Queries.SAPQueries.GetBPByCPF;
using SAP_MAGENTO.Mediator.Queries.SAPQueries.GetBPById;
using SAP_MAGENTO.Models.SAPModels;
using static SAP_MAGENTO.Mediator.Commands.SAPCommands.InsertBpCommand.InsertBusinessPartnerCommand;
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

                   return Results.Ok(newBusinessPartner);  

            }).Produces<SAPBusinessPartner>(statusCode: StatusCodes.Status200OK)
              .Produces<SAPBusinessPartner>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-BusinessPartner-SAP")
              .WithOpenApi();

               app.MapPost("/businesspartner-sap", async (IMediator mediator, [FromBody] BusinessPartnerRequest business) =>
            {                   
                   var businessPartner = new GetBPByIdQuery(business.CPF);

                    var newBusinessPartner = await mediator.Send(businessPartner);

                   return Results.Ok(newBusinessPartner);  

            }).Produces<BusinessPartnerSAP>(statusCode: StatusCodes.Status200OK)
              .Produces<BusinessPartnerSAP>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-BusinessPartner By Id-SAP")
              .WithOpenApi();

            app.MapPost("/businesspartner/", async (IMediator mediator,[FromBody] SAPBusinessPartnerCommand command ) =>
            {     
              //Buscar Se Existe CPF Cadastrado
              var verifyIfBPExist = new GetBPByCPFQuery(command.BPFiscalTaxIDCollection[0].TaxId4);

              var confirmIfBPExist = await mediator.Send(verifyIfBPExist);

              if(confirmIfBPExist != null)
               return Results.Conflict();

              var createNewBPInSAP = new SAPBusinessPartnerCommand(command.CardName, command.Phone1, command.EmailAddress, command.BPFiscalTaxIDCollection, command.BPAddresses);

              var businessPartner = await mediator.Send(createNewBPInSAP);
                          
              return Results.Ok(businessPartner);             

              
            }).Produces<BusinessPartnerSAP>(statusCode: StatusCodes.Status200OK)
              .Produces<BusinessPartnerSAP>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Post-BusinessPartner-SAP")
              .WithOpenApi();

           

            return app;
        }
    }
}