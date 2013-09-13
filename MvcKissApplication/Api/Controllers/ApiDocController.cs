using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.OutputCache;

namespace MvcKissApplication.Api.Controllers
{
    public class ApiDocController : ApiController
    {
        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IEnumerable<object> Get()
        {
            return GlobalConfiguration.Configuration.Services.GetApiExplorer()
                .ApiDescriptions
                .Select(x => new
                {
                    httpMethod = x.HttpMethod.Method,
                    relativePath = x.RelativePath,
                    documentation = x.Documentation,
                    parameters = x.ParameterDescriptions.Select(p => new { 
                        name = p.Name, 
                        documentation = p.Documentation, 
                        source = p.Source })
                });
        }
    }
}
