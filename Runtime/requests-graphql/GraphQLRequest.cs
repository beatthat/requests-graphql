using BeatThat.Requests;
using BeatThat.Serializers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BeatThat.Requests.GraphQL
{
    [System.Serializable]
    public struct Query
    {
        public string query;
        public IDictionary<string, object> variables;
    }

    public class GraphQLRequest<T> : WebRequest<GraphQLResponse<T>>
    {
        public GraphQLRequest(
            string url,
            Query query,
            float delay = 0f,
            Reader<GraphQLResponse<T>> itemReader = null)
            : base(url, HttpVerb.POST, delay, itemReader)
        {
            this.query = query;
            SetBody(JsonConvert.SerializeObject(this.query, Formatting.None));
        }

        public Query query { get; set; }

        /**
         * Converts this graphql request into a request for the underlying
         * data item by wrapping the request in a promise.
         * The promise should either successfully resolve the item
         * or error.
         */
        public Request<T> ToItemRequest()
        {
            return new Promise<T>((resolve, reject, cancel, attach) =>
            {
                attach(this);
                Execute(res =>
                {
                    if (res.hasError)
                    {
                        reject(res);
                    }
                    else
                    {
                        resolve(res.item.data);
                    }
                });
            });
        }

        protected override void DoOnDone()
        {
            if(this.item.errors != null && this.item.errors.Length > 0)
            {
                this.error = this.item.errors[0].message;
            }
            base.DoOnDone();
        }

    }

    // default should have a Dictionary<string,object> for data, but no user yet and need to test nested dictionary serialization

    //public class GraphQLRequest : GraphQLRequest<Dictionary<string, object>>
    //{
    //    public GraphQLRequest(
    //        string query,
    //        AccountState account,
    //        string url,
    //        HttpVerb httpVerb = HttpVerb.GET,
    //        float delay = 0f,
    //        Reader<GraphQLResponse<Dictionary<string,object>>> itemReader = null)
    //        : base(query, account, url, httpVerb, delay, itemReader)
    //    {
    //    }
    //}
}
