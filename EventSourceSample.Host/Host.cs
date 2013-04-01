using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Hosting.Self;

namespace EventSourceSample.Host
{
    public class Host
    {
        public static void Main(string[] args)
        {
            var type = typeof (EventModule).ToString();
            var host = new NancyStreamHost(new Uri("http://localhost:1235"));
            host.Start();
            Console.WriteLine("host started at " + "http://localhost:1235");
            Console.WriteLine("press key to stop");
            Console.Read();
            host.Stop();
        }
    }
}
