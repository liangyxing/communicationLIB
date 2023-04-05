using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OPCDA.DATools
{
    public class CheckHostStatus
    {
        /// <summary>
        /// 检查IP是否可用
        /// </summary>
        /// <param name="ipAddress">IP地址，不可输入IP别名，例如：localhost</param>
        /// <returns>true:可用，false：不可用</returns>
        public async Task<bool> IsPingableAsync(string ipAddress)
        {
            if (ipAddress == "localhost")
                ipAddress= "127.0.0.1";

            using var ping = new Ping();
            var reply = await ping.SendPingAsync(ipAddress);
            return reply.Status == IPStatus.Success;
        }
    }
}
