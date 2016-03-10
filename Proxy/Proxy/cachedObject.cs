using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class CachedObject
    {
        // A list where all the cached objects will be placed
        public static List<CachedObject> cachedObjectsList = new List<CachedObject>();
        public string request;
        public string response;

        public CachedObject(string request, string response)
        {
            this.request = request;
            this.response = response;
        }
    }
}
