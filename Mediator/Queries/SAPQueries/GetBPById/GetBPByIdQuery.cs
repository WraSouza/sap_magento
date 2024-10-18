

using MediatR;
using SAP_MAGENTO.Models.SAPModels;

namespace SAP_MAGENTO.Mediator.Queries.SAPQueries.GetBPById
{
    public class GetBPByIdQuery : IRequest<BusinessPartnerSAP>
    {         
        public GetBPByIdQuery(string cpf)
        {
            CPF = cpf;
        }

        public GetBPByIdQuery()
        {
            
        }

        public string CardName { get; set; } = string.Empty;        
        public string Rua { get; set; }  = string.Empty;      
        public string Numero { get; set; } = string.Empty;        
        public string Bairro { get; set; } = string.Empty;        
        public string ZipCode { get; set; } = string.Empty;        
        public string Cidade { get; set; } = string.Empty;
        public string? Telefone { get; set; } = string.Empty;        
        public string CPF { get; set; } = string.Empty;        
        public string Email { get; set; } = string.Empty;
    }
}