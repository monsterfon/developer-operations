using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Subproject2;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter path to slices directory: ");
            string slicesDirectory = Console.ReadLine();
            slicesDirectory = slicesDirectory.Trim('"');
            // Check if directory exists
            Console.WriteLine($"Checking directory: {slicesDirectory}");
            if (!Directory.Exists(slicesDirectory))
            {
                Console.WriteLine($"Directory does not exist: {slicesDirectory}");
                return;
            }
            Console.WriteLine($"Directory exists: {slicesDirectory}");

            var stopwatch = Stopwatch.StartNew();
            var processor = new SliceProcessor();
            var sliceInfos = processor.ProcessSlices(slicesDirectory);
            stopwatch.Stop();
            Console.WriteLine($"Total processing time: {stopwatch.Elapsed.TotalMinutes:F2} minutes");
        }
    }
}