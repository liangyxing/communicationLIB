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
        public void ConfigDAHost(string groupName,string machineName,string serverName)
        {
            
            reader = new DAReader(groupName);
            reader.Connect("localhost", serverName);
            reader.CreateGroup();
            reader.LoadNodes(machineName);
        }

        //public async Task<ItemValueResult[]> Reader()
        //{
        //    Tasks tasks = new Tasks();
        //    tasks.Add(reader);
        //    //return await reader.ReadAsync();
        //}        
        public void Reader()
        {
            Tasks tasks = new Tasks();
            tasks.Add(reader);
            //return await reader.ReadAsync();
        }

    }
}
