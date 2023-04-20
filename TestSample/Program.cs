using OPCDA.DATasks;
using OPCDA.DATools;
using OPCDA.DAServices;
namespace TestSample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //GetServers get=new GetServers();
            ////var res=get.Get("localhos");
            //CheckHostStatus check=new CheckHostStatus();
            //var res= await check.IsPingableAsync("192.168.23.43");
            //ConnectToServer connectToServer=new ConnectToServer();
            //var conn=connectToServer.Connect("localhost", "Kemro.opc.4.IF1.1.94a");


            #region
            //DAReader dAReader = new DAReader("test");
            ////Kepware.KEPServerEX.V6
            ////var server = dAReader.Connect("localhost", "Kemro.opc.4.IF1.1.94a");            
            //var server = dAReader.Connect("localhost", "Kepware.KEPServerEX.V6");
            //dAReader.CreateGroup();
            //dAReader.LoadNodes();
            //Tasks tasks = new Tasks();
            //tasks.Add(dAReader);
            #endregion

            #region
            //ConfigDB.DBContext.SqlLiteDBContext context = new ConfigDB.DBContext.SqlLiteDBContext();
            //var res = context.dANodeInfoModels.FirstOrDefault();
            //await Console.Out.WriteLineAsync(res?.ToString());
            #endregion

            Servicses servicses = new Servicses();
            await servicses.SaveNodeServiceAsync("keba",@"D:\Desktop\NodeFiles\nodes.csv");
            while (true) { }


        }
    }
}