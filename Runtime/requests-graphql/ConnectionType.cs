using System;

namespace BeatThat.Requests.GraphQL
{
    [Serializable]
    public class ConnectionType<T>
    {
        public EdgeType<T>[] edges { get; set; }
        public PageInfo pageInfo { get; set; }
    }
}