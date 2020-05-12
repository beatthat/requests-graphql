using System;

namespace BeatThat.Requests.GraphQL
{
    [Serializable]
    public struct GraphQLError
    {
        public string message;
    }

    [Serializable]
    public struct GraphQLResponse<T>
    {
        public T data;
        public GraphQLError[] errors;
    }
}
