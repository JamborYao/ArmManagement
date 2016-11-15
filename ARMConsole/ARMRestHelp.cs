using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace ARMTemplate
{
    public class ARMRestHelp
    {
        private static AdInfo adInfo { get; set; }
        public ARMRestHelp()
        {
            using (var file = File.OpenText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + ("/ADSettings.json")))
            {
                string content = file.ReadToEnd();
                var adApplication = JsonConvert.DeserializeObject<AdApplication>(content);
                adInfo = adApplication.Application;

            }
        }

        public async Task GetToken()
        {
            AuthenticationResult result = null;
            string test;
            AuthenticationContext authContext = new AuthenticationContext(adInfo.AuthUrl + adInfo.Telnant);
            try
            {
                result = await authContext.AcquireTokenAsync(adInfo.Resource, adInfo.ClientId, new Uri(adInfo.ReturnUrl), new PlatformParameters(PromptBehavior.Auto));
                test = result.AccessToken;
            }
            catch (AdalException ex)
            {
                // An unexpected error occurred, or user canceled the sign in.



            }


        }
    }
}