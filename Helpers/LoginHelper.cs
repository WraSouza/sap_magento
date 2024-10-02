
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SAP_MAGENTO.Models.SAPModels;

namespace SAP_MAGENTO.Helpers
{
    public class LoginHelper(IOptions<LoginSAP> option, IMemoryCache memoryCache)
    {       
        private readonly string LOGIN_TOKEN = "SAPToken";
        public async Task<TokenSAP> RealizarLogin()
        {
            if(memoryCache.TryGetValue(LOGIN_TOKEN, out TokenSAP? tokenSAP))
            {
                return tokenSAP;
            }

            TokenSAP? newResponse; 

            HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; 

            string responseBody = string.Empty;           

            var login = new LoginSAP( option.Value.UserName, option.Value.Password, option.Value.CompanyDB);           

             string json = JsonConvert.SerializeObject(login);

             StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

              using (var client = new HttpClient(clientHandler))
              {
                   HttpResponseMessage response = await client.PostAsync("https://linux-7lxj:50000/b1s/v1/Login", content);
             
                   responseBody = await response.Content.ReadAsStringAsync();

                   newResponse =  JsonConvert.DeserializeObject<TokenSAP>(responseBody);
              } 

            var memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1800),
                SlidingExpiration = TimeSpan.FromSeconds(1000)
            };

             memoryCache.Set(LOGIN_TOKEN, newResponse);            
                
             return newResponse;
        }
    }
}