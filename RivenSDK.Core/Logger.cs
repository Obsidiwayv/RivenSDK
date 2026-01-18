using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RivenSDK.Core
{
    public class LoggerSector(string sectorName, string fileName)
    {
        public void Write(string content)
        {
            var file = File.ReadAllText(fileName);
            file += $"[{DateTime.UtcNow:hh:mm:ss}] -> {sectorName} -> {content}\n";

            File.WriteAllText(fileName, file);
        }
    }

    public class Logger
    {
        private string Output { get; set; } = "";

        private string FileName { get; }
            = $"{DateTime.Now:ddhmmyyyy}.log";

        public Logger(string folder)
        {
            Output = $"{folder}/{FileName}";
            RivenFS.CheckDirectory(folder);

            File.Create(Output);
        }

        public LoggerSector UseSector(string sectorName)
        {
            return new LoggerSector(sectorName, Output);
        }
    }
}
