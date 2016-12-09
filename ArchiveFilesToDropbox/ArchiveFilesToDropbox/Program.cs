using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace ArchiveFilesToDropbox
{
    class Program
    {
        private static ILogger Logger;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Environment.SetEnvironmentVariable("BASEDIR", AppDomain.CurrentDomain.BaseDirectory);
            Logger = new LoggerConfiguration().ReadFrom.AppSettings().CreateLogger();

            Logger.Information("Test:{0}", "hello");
        }
    }
}
