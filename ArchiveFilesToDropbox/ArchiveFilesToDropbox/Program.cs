using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            try
            {
                var archiveFolderPath = ConfigurationManager.AppSettings["archiveFolder"];
                int takeFile = int.Parse(ConfigurationManager.AppSettings["noOfLatestFileToArchive"] ?? "1");
                var archiveFolder = new DirectoryInfo(archiveFolderPath);
                Logger.Information("Getting archive folder:{archiveFolder}", archiveFolder);
                var matchingFiles = archiveFolder.GetFiles().OrderByDescending(f => f.LastWriteTime).Take(takeFile);

                foreach (var file in matchingFiles)
                {
                    
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "");
            }
        }
    }
}
