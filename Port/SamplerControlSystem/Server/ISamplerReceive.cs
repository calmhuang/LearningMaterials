using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplerControlSystem.Server
{
    internal interface ISamplerReceive
    {
        void Receive(string data, ref string version, ref bool receiveStatus);

        void Receive(string data, ref bool receiveStatus);

        void Receive(string data, ref bool receiveStatus, ref bool connectStatus);
    }
}
