using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCDA.Entity
{
    public class TaskInfo
    {
        public CancellationTokenSource Cts { get; set; }
        public Task Task { get; set; }
        public ManualResetEvent ResetEvent { get; set; }
        public Process CurrentProcess { get; set; }
    }
}
