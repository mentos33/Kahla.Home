using Aiursoft.Pylon.Exceptions;
using Aiursoft.Pylon.Models;
using Aiursoft.Pylon.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kahla.Home.Services
{
    public class VersionChecker
    {
        private readonly HTTPService _http;
        public VersionChecker(HTTPService http)
        {
            _http = http;
        }

        public async Task<string> CheckKahla()
        {
            var url = new AiurUrl("https://raw.githubusercontent.com", "/AiursoftWeb/Kahla.App/master/package.json", new { });
            var response = await _http.Get(url);
            var result = JsonConvert.DeserializeObject<NodePackageJson>(response);
            if (result.Name.ToLower() == "kahla")
            {
                return result.Version;
            }
            else
            {
                throw new AiurUnexceptedResponse(new AiurProtocal()
                {
                    Code = ErrorType.NotFound,
                    Message = "GitHub Json response is not related with Kahla!"
                });
            }
        }
    }

    public class NodePackageJson
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
}
