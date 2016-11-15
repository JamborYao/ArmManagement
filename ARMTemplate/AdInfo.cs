using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARMTemplate
{
    public class AdInfo
    {
        [JsonProperty(PropertyName = "clientid")]
        public string ClientId { get; set; }
        [JsonProperty(PropertyName = "clientsecret")]
        public string ClientSecret { get; set; }
        [JsonProperty(PropertyName = "returnurl")]
        public string ReturnUrl { get; set; }
        [JsonProperty(PropertyName = "telnantid")]
        public string Telnant { get; set; }
        [JsonProperty(PropertyName = "authurl")]
        public string  AuthUrl { get; set; }
        [JsonProperty(PropertyName = "resource")]
        public string Resource { get; set; }

    }
    public class AdApplication
    {
        [JsonProperty(PropertyName = "ARMTemplate")]
        public AdInfo Application { get; set; }
        [JsonProperty(PropertyName = "subscription")]
        public string Subscription { get; set; }
    }
}