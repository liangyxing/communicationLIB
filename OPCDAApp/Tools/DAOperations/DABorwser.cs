using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Da;
using OPCDA.DATools;
using OPCDA.DATasks;
namespace OPCDAApp.Tools.DAOperations
{
    public class DABorwser
    {
        DAReader reader;
        public ItemValueResult[] res { get; set; }
        public void ConfigDAHost(string groupName,string machineName,string serverName)
        {
            
            reader = new DAReader(groupName);
            reader.Connect("localhost", serverName);
            reader.CreateGroup();
            reader.LoadNodes(machineName);
        }
     
        public void Reader(Func<ItemValueResult[], ItemValueResult[]>CallBack)
        {
            Tasks tasks = new Tasks();
            //var callBack = new Func<ItemValueResult[], ItemValueResult[]>(CallBack);
            tasks.Add(reader, CallBack);
            tasks.taskList[0].ResetEvent.Set();
            
        }



    }
}
