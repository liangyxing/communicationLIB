using OPCDA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OPCDA.DATools
{
    public class ConnectToServer
    {
        ConnectInfo connectMsg=new ConnectInfo();
        public ConnectInfo Connect(string host,string daServerName)
        {
            OpcCom.Factory factory = new OpcCom.Factory();
            using Opc.Da.Server server = new Opc.Da.Server(factory, null) ;
            try
            {
                server.Url = new Opc.URL($"opcda://{host}/{daServerName}");
                server.Connect();
                connectMsg.IsSuccess = server.IsConnected;
                connectMsg.Message = "connect success";
                connectMsg.Server= server;
                return connectMsg;
                
            }
            catch(Exception ex)
            {
                connectMsg.IsSuccess =false;
                connectMsg.Message = "host or daServer maybe erroe";
                connectMsg.Server = null;
                return connectMsg;
            }            
        }
    }
}
