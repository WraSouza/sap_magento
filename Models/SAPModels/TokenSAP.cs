using Newtonsoft.Json;

namespace SAP_MAGENTO.Models.SAPModels
{
    public class TokenSAP
    {
         [JsonProperty("odata.metadata")]
        public string odatametadata { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public int SessionTimeout { get; set; }
        
    }
}