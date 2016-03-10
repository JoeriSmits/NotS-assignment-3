using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    class CachedObject
    {
        // A list where all the cached objects will be placed
        public static List<CachedObject> CachedObjectsList = new List<CachedObject>();
        public string Request;
        public string Response;

        /// <summary>
        /// CachedObject constructor
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public CachedObject(string request, string response)
        {
            this.Request = request;
            this.Response = response;

            // Start a timer to remove the item from the list when cached timeout
            var t = new Timer(RemoveCachedObject, null, Proxy.CacheTimeValue, Proxy.CacheTimeValue);
        }

        /// <summary>
        /// Timer callback for the cached object. It removes the current object out the list.
        /// </summary>
        /// <param name="e"></param>
        private void RemoveCachedObject(Object e)
        {
            CachedObjectsList?.Remove(this);
        }
    }
}
