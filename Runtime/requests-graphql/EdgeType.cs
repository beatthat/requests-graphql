using System;

namespace BeatThat.Requests.GraphQL
{
    [Serializable]
    public class EdgeType<T>
    {
        public T node { get; set; }
        public string cursor;
    }
}