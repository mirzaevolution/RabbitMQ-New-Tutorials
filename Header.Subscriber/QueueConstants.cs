using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Header.Subscriber
{
    public class QueueConstants
    {
        public static readonly KeyValuePair<string, IDictionary<string, object>> CustomerCreated =
            new KeyValuePair<string, IDictionary<string, object>>("logs.header.customer.created", new Dictionary<string, object>
            {
                {"type","customer" },
                { "event","created" },
                {"x-match","all" }
            });
        public static readonly KeyValuePair<string, IDictionary<string, object>> CustomerUpdated =
            new KeyValuePair<string, IDictionary<string, object>>("logs.header.customer.updated", new Dictionary<string, object>
            {
                {"type","customer" },
                {"event","updated"},
                {"x-match","any"}
            });
        public static readonly KeyValuePair<string, IDictionary<string, object>> CustomerDeleted =
            new KeyValuePair<string, IDictionary<string, object>>("logs.header.customer.deleted", new Dictionary<string, object>
            {
                { "type","customer"},
                { "event","deleted" },
                {"x-match","all" }
            });
        public static readonly KeyValuePair<string, IDictionary<string, object>> OrderPlaced =
            new KeyValuePair<string, IDictionary<string, object>>("logs.header.order.placed", new Dictionary<string, object>
            {
                {"type","order" },
                {"event","placed" },
                {"x-match","all" }
            });


    }
}
