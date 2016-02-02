using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackMamba.Framework.Core.Helper
{
   public class NetworkHelper
    {
        public static List<string> IpList;
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }

        public static async Task<List<PingReply>> PingAsync(List<string> ips)
        {
            Ping pingSender = new Ping();
            var tasks = ips.Select(ip => pingSender.SendPingAsync(ip, 2000));
            var results = await Task.WhenAll(tasks);

            return results.ToList();
        }


        public static async Task PingHostsAsync(List<string> Ips, Action<string> action)
        {
            if (Ips.Count == 0)
                throw new ArgumentException("Ping needs a host or IP Address.");

            IpList = Ips;
            AutoResetEvent waiter = new AutoResetEvent(false);
            Ping pingSender = new Ping();

            // When the PingCompleted event is raised,
            // the PingCompletedCallback method is called.
            //pingSender.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            // Wait 4 seconds for a reply.
            int timeout = 4000;

            // Set options for transmission:
            // The data can go through 64 gateways or routers
            // before it is destroyed, and the data packet
            // cannot be fragmented.
            PingOptions options = new PingOptions(64, true);

            List<string> cannotAccessIps = new List<string>();
            foreach (var ipItem in Ips)
            {
                //pingSender.SendAsync(ipItem, timeout, buffer, options, waiter);
                // pingSender.send //(ipItem, timeout, buffer, options, waiter);
                var reply = await new Ping().SendPingAsync(ipItem, timeout, buffer, options);
                //if (reply.Status != IPStatus.Success)
                //{
                //    cannotAccessIps.Add(ipItem);
                //    if (action!=null)
                //    {
                //        action(ipItem);
                //    }
                //}
            }
            // Send the ping asynchronously.
            // Use the waiter as the user token.
            // When the callback completes, it can wake up this thread.

            // Prevent this example application from ending.
            // A real application should do something useful
            // when possible.
            //waiter.WaitOne();
            // return cannotAccessIps;
        }

        private static void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            // If the operation was canceled, display a message to the user.
            if (e.Cancelled)
            {
                //Console.WriteLine("Ping canceled.");

                // Let the main thread resume. 
                // UserToken is the AutoResetEvent object that the main thread 
                // is waiting for.
                // ((AutoResetEvent)e.UserState).Set();
            }

            // If an error occurred, display the exception to the user.
            if (e.Error != null)
            {
                //Console.WriteLine("Ping failed:");
                //Console.WriteLine(e.Error.ToString());

                // Let the main thread resume. 
                ((AutoResetEvent)e.UserState).Set();
            }

            PingReply reply = e.Reply;

            HandleReply(reply);

            // Let the main thread resume.
            ((AutoResetEvent)e.UserState).Set();
        }

        private static void HandleReply(PingReply reply)
        {

        }

    }
}
