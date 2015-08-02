using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Management;
using System.IO;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace ChildrenRandom
{
    class GetMac
    {
        public string GetMACAddress()
        {
            return
         (from nic in NetworkInterface.GetAllNetworkInterfaces()
       where nic.OperationalStatus == OperationalStatus.Up
       select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
        }
    }
}
