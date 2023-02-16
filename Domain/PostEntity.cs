using System;
namespace TopoServices.Domain
{
    public class PostEntity
    {

        public PostEntity()
        {

        }
        public PostEntity(Guid postId, string title)
        {
            PostId = postId;
            Title = title;
        }
        public Guid PostId { get; set; }

        public string Title { get; set; }
    }
}
