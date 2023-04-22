using OPCDA.DATools;
using OPCDA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCDAApp.Tools.DAOperations
{
    public class GetHostDALists
    {
        public List<ServerItem> Get()
        {
            var res = new GetServers().Get("localhost");
            return res;
        }
    }
}
