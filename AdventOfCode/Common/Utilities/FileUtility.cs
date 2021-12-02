using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Common.Utilities
{
    public static class FileUtility
    {
        public static IList<int> FileInputToNumberList(string filePath)
            => File.ReadAllLines(filePath).Select(int.Parse).ToList();
    }
}