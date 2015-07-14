using System;
using LionheadTest.API;
using Microsoft.Owin.Hosting;

namespace LionheadTest.Host
{
    class Program
    {
        static void Main()
        {
            const string urlBase = "http://localhost:9000";

            WebApp.Start<Startup>(url: urlBase);

            Console.ReadLine();
        }
    }
}
