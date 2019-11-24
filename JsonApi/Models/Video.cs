using JsonApiDotNetCore.Models;

namespace JsonApi.Models
{
    public class Video : Identifiable
    {
        [Attr("name")]
        public string Name { get; set; }

        [Attr("description")]
        public string Description { get; set; }

        [Attr("thumbnail")]
        public string Thumbnail { get; set; }

        [Attr("videoUrl")]
        public string VideoUrl { get; set; }
    }
}
