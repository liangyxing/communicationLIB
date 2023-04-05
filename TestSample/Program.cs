using OPCDA.DATools;

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

            DAReader dAReader = new DAReader("test");
            dAReader.Connect("localhost", "Kepware.KEPServerEX.V6");
            dAReader.CreateGroup();
            dAReader.LoadNodes();
            dAReader.Read();

           // Console.ReadLine();
        }
    }
}