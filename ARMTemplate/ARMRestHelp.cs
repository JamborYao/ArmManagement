using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;

namespace ARMTemplate
{
    public class ARMRestHelp
    {
        private static AdInfo adInfo { get; set; }
        private static AdApplication adApplication { get; set; }
        public ARMRestHelp()
        {
            using (var file = File.OpenText(HttpContext.Current.Server.MapPath("ADSettings.json")))
            {
                string content = file.ReadToEnd();
                adApplication = JsonConvert.DeserializeObject<AdApplication>(content);
                adInfo = adApplication.Application;
               
            }
        }

        public async Task<string> GetToken()
        {
            AuthenticationResult result = null;
            string test;
            AuthenticationContext authContext = new AuthenticationContext(adInfo.AuthUrl + adInfo.Telnant);
            ClientCredential cc = new ClientCredential(adInfo.ClientId, adInfo.ClientSecret);
            try
            {
                result = await authContext.AcquireTokenAsync(adInfo.Resource,cc);               
                test = result.AccessToken;
                return test;
            }
            catch (AdalException ex)
            {
                return ex.Message;
            }   
        }

        public async Task GetSQLInfo()
        {
            string token = await GetToken();
            var sqlclient = new SqlManagementClient(new TokenCloudCredentials(adApplication.Subscription, token));
            var data = await sqlclient.Databases.GetAsync("jatestgroup", "jaserver", "jasql");
        }

        public async Task GetResourceGroup()
        {
            string token = await GetToken();    
            var rmClient = new ResourceManagementClient(new TokenCloudCredentials(adApplication.Subscription, token));
            ResourceGroupGetResult result = await rmClient.ResourceGroups.GetAsync("jatestgroup");
        }

      
    }
}