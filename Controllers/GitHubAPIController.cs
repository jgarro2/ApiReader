using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ApiReader.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ApiReader.Controllers
{
    public class GitHubApiController : Controller
    {
        private GitHubApiResultModel DownloadApiResults(string url)
        {
            var client = new RestClient(url);
            var response = client.Execute<GitHubApiResultModel>(new RestRequest());
            return response.Data;
        }

        private List<GitHubRepoModel> GetReposFromGitHubData(GitHubApiResultModel gitHubApiResults)
        {
            List<GitHubRepoModel> listOfRepos = new List<GitHubRepoModel>();
            JArray items = JArray.Parse(gitHubApiResults.items);
            items.Children().ToList();
            

            foreach (var item in items) 
            {
                var js = new JavaScriptSerializer();
                JsonResult json_item = item.ToObject<JsonResult>();                
                listOfRepos.Add(
                        new GitHubRepoModel 
                        {
                            Id = js.Deserialize<GitHubRepoModel>(item.ToString()).Id,
                            Name = js.Deserialize<GitHubRepoModel>(item.ToString()).Name,
                            Html_Url = js.Deserialize<GitHubRepoModel>(item.ToString()).Html_Url,
                            Owner_Login = js.Deserialize<GitHubRepoModel>(item.ToString()).Owner_Login,
                            Stargazers_Count = js.Deserialize<GitHubRepoModel>(item.ToString()).Stargazers_Count
                        }
                    );            

            }
            return listOfRepos;
        }

        public ActionResult Top25Repos()
        {
            string apiQueryUrl = "https://api.github.com/search/repositories?q=stars&sort=stars&order=dsc&per_page=25&page=1";
            List<GitHubRepoModel> listOfRepos = GetReposFromGitHubData(DownloadApiResults(apiQueryUrl));
            ViewData["Message"] = listOfRepos;
            return View();
        }

        private string GetRestResponse(string url)
        {
            var client = new RestClient(url);
            var response = client.Execute(new RestRequest());
            return response.Content;
        }

    }
}