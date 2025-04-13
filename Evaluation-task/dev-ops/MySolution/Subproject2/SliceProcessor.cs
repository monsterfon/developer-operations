using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Subproject1;

namespace Subproject2
{
    public class SliceProcessor
    {
        public List<SliceInfo> ProcessSlices(string slicesDirectory)
        {
            var sliceInfos = new List<SliceInfo>();
            if (!Directory.Exists(slicesDirectory))
            {
                return sliceInfos;
            }

            // Parse each CSV file
            foreach (var file in Directory.GetFiles(slicesDirectory, "*.txt"))
            {

                // Read lines
                var lines = File.ReadAllLines(file)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToArray();

                // Ensure we have at least three lines
                if (lines.Length < 3) 
                {
                    Console.WriteLine($"Skipping file with unexpected format: {file}");
                    continue;
                }

                // Try parsing
                if (!double.TryParse(lines[0], out double zPos))
                {
                    Console.WriteLine($"Skipping file with non-numeric Z-pos: {file}");
                    continue;
                }
                var widthHeight = lines[1].Split(' ');
                if (widthHeight.Length < 2
                    || !int.TryParse(widthHeight[0], out int width)
                    || !int.TryParse(widthHeight[1], out int height))
                {
                    Console.WriteLine($"Skipping file with bad width/height: {file}");
                    continue;
                }

                // Parse data
                var values = lines[2].Split(' ')
                    .Select(double.Parse)
                    .ToArray();

                // Compute min, max, average
                double minVal = double.MaxValue;
                double maxVal = double.MinValue;
                int minIndex = 0;
                int maxIndex = 0;
                double sum = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    var val = values[i];
                    sum += val;
                    if (val < minVal)
                    {
                        minVal = val;
                        minIndex = i;
                    }
                    if (val > maxVal)
                    {
                        maxVal = val;
                        maxIndex = i;
                    }
                }

                double avg = sum / values.Length;
                // Compute (row, col) from index
                int minRow = minIndex / width;
                int minCol = minIndex % width;
                int maxRow = maxIndex / width;
                int maxCol = maxIndex % width;

                sliceInfos.Add(new SliceInfo
                {
                    ZPosition = zPos,
                    Width = width,
                    Height = height,
                    MinValue = minVal,
                    MaxValue = maxVal,
                    AvgValue = avg,
                    MinRow = minRow,
                    MinCol = minCol,
                    MaxRow = maxRow,
                    MaxCol = maxCol
                });
            }

            // If no slices were added
            if (!sliceInfos.Any())
            {
                Console.WriteLine("No valid slice files found.");
                return sliceInfos;
            }

            // Print per-slice table
            Console.WriteLine("\nSlice Position | Dimensions  | Min value (row, col) | Max value (row, col) | Average value");
            foreach (var slice in sliceInfos.OrderBy(s => s.ZPosition))
            {
                Console.WriteLine($"{slice.ZPosition,13} | {slice.Width}x{slice.Height, -8} | {slice.MinValue} ({slice.MinRow},{slice.MinCol}) | {slice.MaxValue} ({slice.MaxRow},{slice.MaxCol}) | {slice.AvgValue:F2}");
            }

            // Compute global stats
            var globalMin = sliceInfos.Min(s => s.MinValue);
            var globalMinSlice = sliceInfos.First(s => s.MinValue == globalMin);
            var globalMax = sliceInfos.Max(s => s.MaxValue);
            var globalMaxSlice = sliceInfos.First(s => s.MaxValue == globalMax);
            var globalAvg = sliceInfos.Average(s => s.AvgValue);

            Console.WriteLine("\nGlobal Results:");
            Console.WriteLine($"Global min: {globalMin} at slice Z={globalMinSlice.ZPosition}, (row={globalMinSlice.MinRow}, col={globalMinSlice.MinCol})");
            Console.WriteLine($"Global max: {globalMax} at slice Z={globalMaxSlice.ZPosition}, (row={globalMaxSlice.MaxRow}, col={globalMaxSlice.MaxCol})");
            Console.WriteLine($"Global average: {globalAvg:F2}");

            return sliceInfos;
        }
    }
}
