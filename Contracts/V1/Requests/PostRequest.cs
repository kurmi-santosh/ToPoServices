using System;
namespace TopoServices.Contracts.V1.Requests
{
    public class PostRequest
    {
        public string Title { get; set; }
    }

    public class UpdateRequest
    {
        public Guid PostId { get; set; }

        public string Title { get; set; }

    }


}
