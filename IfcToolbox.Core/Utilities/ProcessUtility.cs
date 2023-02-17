using Serilog;
using System.Diagnostics;
using System;

namespace IfcToolbox.Core.Utilities
{
    public class ProcessUtility
    {
        public static void ProcessStart(string source, string target, string workingDirectory, string executableName, string optionPrompt = null, bool logDetail = false)
        {
            var info = new ProcessStartInfo();
            string basePath = Environment.CurrentDirectory;
            string relativePath = "/IfcToolbox.Core/Convert/Resources";
            string filePath = basePath + relativePath + "/IfcConvert";
            string workPath = basePath + relativePath;
            // info.FileName = $"\"{Path.Combine(workingDirectory, executableName)}\"";
            // info.FileName = "/home/angelswing/Downloads/IfcConvert/IfcConvert";
            info.FileName = filePath;
            // info,workingDirectory = workingDirectory;
            info.WorkingDirectory = workPath;
            info.Arguments = $"\"{source}\" \"{target}\" {optionPrompt}";


            info.RedirectStandardInput = false;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.RedirectStandardError = true;

            using (var proc = new Process())
            {
                proc.StartInfo = info;
                proc.Start();
                string message = proc.StandardOutput.ReadToEnd();
                string errors = proc.StandardError.ReadToEnd();

                proc.WaitForExit();
                if (logDetail)
                    Log.Information(message);
            }
        }
    }
}
