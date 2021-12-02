using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Common.Fluent.Collections;

namespace AdventOfCode.Common.Utilities
{
    public static class InputUtility
    {
        public static IList<int> FileInputToNumberList(string filePath)
            => File.ReadAllLines(filePath).Select(int.Parse).ToList();
        
        public static Dictionary<K, V> ToDictionary<K, V>(string filePath, Func<string, (K, V)> spliterator)
            => ToDictionary(File.ReadAllLines(filePath), spliterator);
        
        public static Dictionary<K, V> ToDictionary<K, V>(IEnumerable<string> input, Func<string, (K, V)> spliterator)
        {
            var dictionary = new Dictionary<K,V>();

            foreach (var line in input)
            {
                var (key, value) = spliterator(line);
                dictionary[key] = value;
            }

            return dictionary;
        }
        
        public static Dictionary<K, V> SummableToDictionary<K, V>(string filePath, Func<string, (K, V)> spliterator)
            => SummableToDictionary(File.ReadAllLines(filePath), spliterator);
        
        public static Dictionary<K, V> SummableToDictionary<K, V>(IEnumerable<string> input, Func<string, (K, V)> spliterator)
        {
            var dictionary = new Dictionary<K, V>();

            foreach (var line in input)
            {
                var (key, value) = spliterator(line);
                dictionary.SetOrAdd(key, value);
            }

            return dictionary;
        }
    }
}