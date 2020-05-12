using System;

namespace BeatThat.Requests.GraphQL
{
    [Serializable]
    public class PageInfo
    {
        public string endCursor;
        public bool hasNextPage { get; set; }
    }
}