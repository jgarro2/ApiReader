using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ApiReader.Models
{
    public class GitHubRepoModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
       
        [JsonProperty(PropertyName = "html_url")]
        public string Html_Url { get; set; }
        
        [JsonProperty(PropertyName = "owner/login")]
        public string Owner_Login { get; set; }
        
        [JsonProperty(PropertyName = "stargazers_count")]
        public int Stargazers_Count { get; set; }
    }
}