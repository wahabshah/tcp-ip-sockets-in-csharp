using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace IPAddressExample
{
    class Program
    { 
        static void PrintHostInfo(String host)
        {
            try
            { 
                // Attempt to resolve (Resolve/GetHostByName) DNS for given host or address
                IPHostEntry hostInfo = Dns.GetHostByName(host);

                //Display the primary host name
                Console.WriteLine($"Canonical Name: {hostInfo.HostName}");

                //Display list of IP addresses for this host
                Console.WriteLine("IP Addresses: ");
                foreach (IPAddress ipaddr in hostInfo.AddressList)
                    Console.WriteLine(ipaddr.ToString());
                Console.WriteLine();

                //Display list of alias names for this host
                Console.WriteLine("Aliases: ");
                foreach (String alias in hostInfo.Aliases)
                    Console.WriteLine($"alias: {alias}");
                Console.WriteLine();


            }catch(Exception ex)
            {
                Console.WriteLine($"Unable to resolve host:{host}");
            }
        }

        static void Main(string[] args)
        {
            //Get and print local host info
            try
            {
                Console.WriteLine("Local Host:");
                String localHostName = Dns.GetHostName();
                Console.WriteLine($"Host Name: {localHostName}");
                PrintHostInfo(localHostName);

            }catch(Exception ex)
            {
                Console.WriteLine("Unable to resolve local host");
            }
            
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
