using IfcToolbox.Core.Analyse;
using IfcToolbox.Core.Utilities;
using IfcToolbox.Examples.Batch;
using IfcToolbox.Examples.Samples;
using IfcToolbox.Tests;
using IfcToolbox.Tools.Processors;
using IfcToolbox.Examples.Utility;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace IfcToolbox.Examples
{
    public static class SampleProcess
    {
        // ATTENTION: Do not forget to replace your own local Output Folder
        private static string OutputFolder = LocalFiles.TestOutputFolder;

        public static void Start(string[] args)
        {

            // Type your username and press enter
            // Console.WriteLine("Enter the Path for the file you want to convert:");

            // Create a string variable and get user input from the keyboard and store it in the variable
            // var pathName = Console.ReadLine();
            var pathName = args[0];

            // Print the value of the variable (userName), which will display the input value
            Console.WriteLine("Path is: " + pathName);

            var result = Path.Combine(pathName.Replace(".ifc", ""));
            Console.WriteLine(result);

            if (!File.Exists(pathName))
            {
                throw new FileNotFoundException(pathName + "doesn't exist");
            }

            EntityAnalyse.AnalyseHierarchy(pathName, true);
            AnalyseProcessor.GetGeoReference(pathName, null, true);

            DirectoryInfo di = new DirectoryInfo(result);
            string[] List = result.Split("/");

            if (!di.Exists)
            {
                di.CreateSubdirectory(List[^1]);
            }
            IfcSplitterSample.SplitByBuildingStorey(pathName.CopyToOutputFolder(result));
            Console.WriteLine("Success");

            var fileList = new GetBuildingStoreyId().GetAllFiles(result + "/");

            // Create a new list to store the filtered file paths
            List<string> filteredFilePaths = new List<string>();

            // Iterate through the file paths and add the ones that don't contain "Building.ifc"
            foreach (string filepath in fileList)
            {
                if (!filepath.Contains(pathName.Split("/")[^1]))
                {
                    filteredFilePaths.Add(filepath);
                }
            }

            // // Print the filtered file paths
            // Console.WriteLine("Filtered Paths:");
            // foreach (string filepath in filteredFilePaths)
            // {
            //     Console.WriteLine(filepath);
            // }

            foreach (var file in filteredFilePaths)
            {
                IfcConverterSample.ConvertToObj(file.CopyToOutputFolder(result + "/"));
            }

            //EntityAnalyse.AnalyseEntityFrequency(LocalFiles.Ifc4_Revit_ARC, true);
            //IfcOptimizerSample.Optimize(LocalFiles.Ifc4_Revit_ARC.CopyToOutputFolder());

            //AnalyseProcessor.GetGeoReference(LocalFiles.Ifc4_Revit_ARC, null, true);
            //IfcRelocatorSample.RelocateToOrigin(LocalFiles.Ifc4_Revit_ARC.CopyToOutputFolder(), 3371);

            // EntityAnalyse.AnalyseHierarchy(LocalFiles.Ifc2x3_Korean_Building, true);
            // IfcSplitterSample.SplitByBuildingStorey(LocalFiles.Ifc2x3_Korean_Building.CopyToOutputFolder());


            //IfcConverterSample.ConvertToSvg(LocalFiles.Ifc4_SampleHouse.CopyToOutputFolder());
            // IfcConverterSample.ConvertToObj(LocalFiles.Ifc4_SampleHouse.CopyToOutputFolder());

            //IfcAnonymizerSample.AnonymizeUserInfo(LocalFiles.Ifc4_SampleHouse.CopyToOutputFolder());
            //IfcAnonymizerSample.AnonymizeProductInfoWithRules(LocalFiles.Ifc4_SampleHouse.CopyToOutputFolder());

            //IfcValidatorSample.ValidatePropertyExistence(LocalFiles.Ifc4_Revit_ARC_FireRatingAdded.CopyToOutputFolder());

            //SimulationProcessingTime();
        }

        private static void SimulationProcessingTime()
        {
            //ProcessTimeEstimation.IfcOptimizer_TimeEstimate(OutputFolder);
            //ProcessTimeEstimation.IfcRelocator_TimeEstimate(OutputFolder);
            //ProcessTimeEstimation.IfcSplitter_TimeEstimate(OutputFolder);
            //ProcessTimeEstimation.IfcConverter_TimeEstimate(OutputFolder);
        }

        private static string CopyToOutputFolder(this string filePath, string result)
        {
            string copiedIfc = ConsoleFile.GetOutputFileName(filePath, result, "");
            ConsoleFile.CreateCopyIfcFile(filePath, copiedIfc);
            return copiedIfc;
        }
    }
}
