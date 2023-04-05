using Microsoft.VisualBasic.FileIO;
using Opc;
using OpcCom;
using OPCDA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCDA.DATools
{
    public class GetServers
    {
        /// <summary>
        /// 根据IP获取DA服务器列表
        /// </summary>
        /// <param name="hostName">需要链接的IP地址</param>
        /// <returns></returns>
        public List<ServerItem> Get(string hostName)
        {
            List<ServerItem> servers = new List<ServerItem>();
            using OpcCom.ServerEnumerator enumerator = new ServerEnumerator();
            servers.Add(new ServerItem()
            {
                DAType = "COM_DA_30"
                ,  DAServerName= enumerator.GetAvailableServers(Specification.COM_DA_30, hostName, null)
                .Where(i => i != null).Where(i => i != null).Select(i => i.Name).ToList()

            });

            servers.Add(new ServerItem()
            {
                DAType = "COM_DA_20",
                DAServerName = enumerator.GetAvailableServers(Specification.COM_DA_20, hostName, null)
                .Where(i => i != null).Where(i => i != null).Select(i => i.Name).ToList()

            });

            servers.Add(new ServerItem()
            {
                DAType = "COM_DA_10"
                ,DAServerName = enumerator.GetAvailableServers(Specification.COM_DA_10, hostName, null)
                .Where(i => i != null).Where(i => i != null).Select(i => i.Name).ToList()
            });
            return servers ;
        }   
        
    }
}
