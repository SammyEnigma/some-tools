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
                int noOfFileToTake = int.Parse(ConfigurationManager.AppSettings["noOfLatestFileToArchive"] ?? "1");
                int noOfFileToKeep = int.Parse(ConfigurationManager.AppSettings["noOfLatestFileToKeep"] ?? "5");

                var archiveFolder = new DirectoryInfo(archiveFolderPath);
                Logger.Information("Getting archive folder:{archiveFolder}", archiveFolder);
                var archiveFiles = archiveFolder.GetFiles().OrderByDescending(f => f.LastWriteTime).Take(noOfFileToTake);

                noOfFileToKeep = Math.Max(0, archiveFolder.GetFiles().Length - noOfFileToKeep);
                var deleteFiles = archiveFolder.GetFiles().OrderByDescending(f => f.LastWriteTime).Take(noOfFileToKeep);

                foreach (var fileToAchive in archiveFiles)
                {
                    Logger.Information("File to be archived:{0}", fileToAchive.FullName);
                }

                foreach (var fileToDelete in deleteFiles)
                {
                    Logger.Warning("File to be deleted:{0}", fileToDelete.FullName);
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "");
            }
        }
    }
}
