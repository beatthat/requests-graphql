using System.Collections.Generic;

namespace BeatThat.Requests.GraphQL
{
    public static class Extenstions
    {
        public static bool GetNodes<T>(this ConnectionType<T> c, ICollection<T> result, bool includeNullResultItems = false)
        {
            if(c == null || c.edges == null) {
                return false;
            }
            foreach(var x in c.edges) {
                if(x != null && x.node != null) {
                    result.Add(x.node);
                }
                else if(includeNullResultItems) {
                    result.Add(default(T));
                }
            }
            return true;
        }
    }
}
