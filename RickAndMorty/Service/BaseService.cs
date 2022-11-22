using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RickAndMorty.Net.Api.Helpers;
using RickAndMorty.Net.Api.Models.Dto;

namespace RickAndMorty.Net.Api.Service
{
 

    internal class BaseService
    {
        private WebClient Client { get; }
        protected BaseService(string baseAddress)
        {
            Client = new WebClient();
            Client.BaseAddress = baseAddress;
        }
        public T Get<T>(string path)
        {
            string response = Client.DownloadString(path);
            var res = JsonConvert.DeserializeObject<T>(response);
            return res;
        }
        protected IEnumerable<T> GetPages<T>(string url)
        {
            List<T> result = new List<T>();
            var nextPage = -1;
            do
            {
                var dto = Get<PageDto<T>>(nextPage == -1 ? url : $"{url}{(url.Contains("?") ? "&" : "?")}page={nextPage}");
                result.AddRange(dto.Results);

                nextPage = dto.Info.Next.GetNextPageNumber();
            }
            while (nextPage != -1);

            return result;
        }
    }
}
