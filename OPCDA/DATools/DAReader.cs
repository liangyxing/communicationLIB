using CsvHelper;
using Opc.Da;
using OPCDA.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCDA.DATools
{
    public class DAReader
    {

        public ConnectInfo connectMsg = new ConnectInfo();

        private string groupName { get; set; }
        private Subscription subscription { get; set; }
        private Server Server;
        private List<Item> items;
        private SubscriptionState state;
        public DAReader(string groupName)
        {
            this.groupName = groupName;
            items = new List<Item>();
        }


        public ConnectInfo Connect(string host, string daServerName)
        {
            OpcCom.Factory factory = new OpcCom.Factory();
            Server = new Opc.Da.Server(factory, null);
            try
            {
                Server.Url = new Opc.URL($"opcda://{host}/{daServerName}");
                Server.Connect();
                connectMsg.IsSuccess = Server.IsConnected;
                connectMsg.Message = "connect success";
                connectMsg.Server = Server;
                return connectMsg;

            }
            catch (Exception ex)
            {
                connectMsg.IsSuccess = Server.IsConnected;
                connectMsg.Message = "host or daServer maybe erroe";
                connectMsg.Server = null;
                return connectMsg;
            }
        }


        public void Disconnect()
        {
            Server.Disconnect();
            Server.Dispose();
            connectMsg.IsSuccess = Server.IsConnected;
            connectMsg.Message = "host disconnect and dispose";
            connectMsg.Server = Server;
        }

        public void  CreateGroup()
        {
            //设定组状态
            state = new Opc.Da.SubscriptionState();//组（订阅者）状态，相当于OPC规范中组的参数
            state.Name = this.groupName;//组名
            state.ServerHandle = null;//服务器给该组分配的句柄。
            state.ClientHandle = Guid.NewGuid().ToString();//客户端给该组分配的句柄。
            state.Active = true;//激活该组。
            state.UpdateRate = 100;//刷新频率为1秒。
            state.Deadband = 0;// 死区值，设为0时，服务器端该组内任何数据变化都通知组。
            state.Locale = null;//不设置地区值。
           
        }

        public void LoadNodes(string machineName)
        {
            IEnumerable<ConfigDB.Entity.DANodeInfoModel> nodeInfos;

            //using (var reader = new StreamReader("./NodeFiles/Core1.csv"))
            //using (var reader = new StreamReader("./NodeFiles/nodes.csv"))
            //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //{
            //    csv.Context.RegisterClassMap<DANodeInfoMap>();
            //     nodeInfos = csv.GetRecords<DANodeInfo>().ToList();
            //}

            using (var reader = new ConfigDB.DBContext.SqlLiteDBContext())
            {
                nodeInfos = reader.dANodeInfoModels.Where(i => i.MachineName == machineName).ToList();

            }
            

            foreach (var nodeInfo in nodeInfos)
                {
                    items.Add(new Item
                    {
                        ClientHandle = Guid.NewGuid().ToString(),
                        ItemPath = null,
                        ItemName = nodeInfo.Address.ToString()
                    });
                }
            this.subscription = (Subscription)Server.CreateSubscription(state);
            var itemss = items.ToArray();
            subscription.AddItems(items.ToArray());
        }

        public async Task<ItemValueResult[]> ReadAsync()
        {
            
            //ItemValueResult[] values;
            var res= await Task.Run(() =>
            {
                return subscription.Read(subscription.Items);
            });

            
            //foreach (var item in res as ItemValueResult[])
            //{
            //    Debug.WriteLine(item.ItemName+":::         "+item.Value + ":::         " + item.Timestamp);
            //}
             return res;
        }
    }
}
