using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SAP_MAGENTO.Models.SAPModels
{
    public class BusinessPartnerResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BusinessPartners
    {
        public string CardCode { get; set; } = string.Empty;
        public string CardName { get; set; } = string.Empty;
        public string Phone1 { get; set; } = string.Empty;
         public string EmailAddress { get; set; } = string.Empty;
    }

    public class BusinessPartnersBPAddresses
    {
        public string BPCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Block { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string StreetNo { get; set; } = string.Empty;
    }

    public class BusinessPartnersBPFiscalTaxIDCollection
    {
        public string BPCode { get; set; } = string.Empty;
        public string TaxId1 { get; set; } = string.Empty;
        public string TaxId4 { get; set; } = string.Empty;
    }

    public class BPResponse
    {
        [JsonProperty("odata.metadata")]
        public string odatametadata { get; set; } = string.Empty;
        public List<Value>? value { get; set; }
    }

    public class Value
    {
        public BusinessPartners? BusinessPartners { get; set; }

        [JsonProperty("BusinessPartners/BPFiscalTaxIDCollection")]
        public BusinessPartnersBPFiscalTaxIDCollection? BusinessPartnersBPFiscalTaxIDCollection { get; set; }

        [JsonProperty("BusinessPartners/BPAddresses")]
        public BusinessPartnersBPAddresses? BusinessPartnersBPAddresses { get; set; }
    }



    }
}