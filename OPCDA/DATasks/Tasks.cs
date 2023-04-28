using Opc.Da;
using OPCDA.DATools;
using OPCDA.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCDA.DATasks
{
   
    public class Tasks
    {
        public List<TaskInfo> taskList = new List<TaskInfo>();
        DAReader Reader;
        public Tasks()
        {

        }
        public TaskInfo Create(DAReader reader)
        {
            Process currentProcess = Process.GetCurrentProcess();
            ManualResetEvent resetEvent = new ManualResetEvent(false);
            CancellationTokenSource cts = new CancellationTokenSource();
            ItemValueResult[] dataReturn=null; 
            Task res= Task.Factory.StartNew(async () =>
            {
                resetEvent.WaitOne();//等开开启线程
                
                try
                {
                    while (true)
                    {

                        dataReturn= await reader.ReadAsync();
                        cts.Token.ThrowIfCancellationRequested();
                        Debug.WriteLine("124");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
                             
            },cts.Token,TaskCreationOptions.LongRunning, TaskScheduler.Default);
            return new TaskInfo
            {
                Task = res,
                Cts = cts,
                ResetEvent=resetEvent,
                CurrentProcess=currentProcess,
                 dataResults=dataReturn
               
            };
        }

        public void Add(DAReader reader)
        {
            taskList.Add(Create(reader));
            Console.WriteLine(taskList[0].Task.Id);
            taskList[0].ResetEvent.Set();


            //while (true)
            //{
            //    ConsoleKeyInfo key = Console.ReadKey();
            //    if (key.KeyChar == '1')
            //    {
            //        taskList[0].ResetEvent.Set();
            //    }
            //    else if (key.KeyChar == '2')
            //    {
            //        taskList[0].Cts.Cancel();
            //    }
            //}
        }

    }
}
