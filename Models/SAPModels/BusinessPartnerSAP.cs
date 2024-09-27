using System.ComponentModel.DataAnnotations;

namespace SAP_MAGENTO.Models.SAPModels
{
    public class BusinessPartnerSAP
    {
        public BusinessPartnerSAP(string cardName, string rua,string numero, string bairro, string zipCode, string cidade, string telefone, string cPF, string email)
        {
            CardName = cardName;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            ZipCode = zipCode;
            Cidade = cidade;
            Telefone = telefone;
            CPF = cPF;
            Email = email;
        }

        [Required]
        public string CardName { get; private set; }
        [Required]
        public string Rua { get; private set; }
        [Required]
        public string Numero { get; private set; }
        [Required]
        public string Bairro { get; private set; }
        [Required]
        [StringLength(9)]
        public string ZipCode { get; private set; }
        [Required]
        public string Cidade { get; private set; }
        public string? Telefone { get; private set; }
        [Required]
        public string CPF { get; private set; }
        [Required]
        public string Email { get; private set; }
    }
}