using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiReader.Models
{
    public class GitHubApiResultModel
    {
        [JsonProperty(PropertyName = "total_count")]
        public int total_count { get; set; }
        
        [JsonProperty(PropertyName = "incomplete_results")]
        public string incomplete_results { get; set; }
        
        [JsonProperty(PropertyName = "items")]
        public string items { get; set; }
    }
}