using CsvHelper;
using Opc.Da;
using OPCDA.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCDA.DATools
{
    public class DAReader
    {
        private string groupName;
        Subscription subscription { get; set; }
        Server Server;
        List<Item> items;
        ConnectInfo connectMsg = new ConnectInfo();
        SubscriptionState state;
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
                connectMsg.IsSuccess = false;
                connectMsg.Message = "host or daServer maybe erroe";
                connectMsg.Server = null;
                return connectMsg;
            }
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

        public void LoadNodes()
        {
            IEnumerable<DANodeInfo> nodeInfos;

            using (var reader = new StreamReader("./NodeFiles/nodes.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<DANodeInfoMap>();
                 nodeInfos = csv.GetRecords<DANodeInfo>().ToList();
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
        }

        public void Read()
        {
            this.subscription = (Subscription)Server.CreateSubscription(state);
            subscription.AddItems(items.ToArray());
            ItemValueResult[] values = subscription.Read(subscription.Items);
            var res= subscription.Items.Length;
            foreach (var item in values)
            {
                Console.WriteLine(item.ItemName+":::         "+item.Value);
            }
        }
    }
}
