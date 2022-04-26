using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add
using System.IO;

namespace BitServicesDesktopApp.Logging
{
    public class FileLogger : LogBase
    {
        string filePath = @"log.txt";

        public override void Log(string message)
        {
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}
