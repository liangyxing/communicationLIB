using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCDA.Entity
{
    public class ConnectInfo
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public Opc.Da.Server Server { get; set; }
    }
}
