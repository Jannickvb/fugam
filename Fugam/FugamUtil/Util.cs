using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FugamUtil
{
    public class Util
    {
        public const int Port = 1100;

        public static IPAddress GetLocalIP()
        {
            return Dns.Resolve(Dns.GetHostName()).AddressList[0];
        }
    }
}
