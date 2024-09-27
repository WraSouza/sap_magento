

namespace SAP_MAGENTO.Models.SAPModels
{
    public class LoginSAP
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Server { get; set; } = string.Empty;
        public string CompanyDB { get; set; } = string.Empty;
        public string DbServerType { get; set; } = string.Empty;
        public bool UseTrusted { get; set; }
    }
}