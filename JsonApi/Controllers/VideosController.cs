using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using JsonApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JsonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : JsonApiController<Video>
    {
        public VideosController(
            IJsonApiContext jsonApiContext,
            IResourceService<Video> resourceService,
            ILoggerFactory loggerFactory)
            : base(jsonApiContext, resourceService, loggerFactory)
        { }
    }
}