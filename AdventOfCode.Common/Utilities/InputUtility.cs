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

        public static List<T[][]> FileInputToMultidimensionalArrays<T>(IEnumerable<string> input,
            Predicate<string> multiArraysSplitCondition, Func<string, string[]> elementSpliterator,
            Func<string, T> converter)
        {
            List<T[][]> result = new();
            List<T[]> tmp = new();
            
            foreach (var line in input)
            {
                if (multiArraysSplitCondition(line))
                {
                    result.Add(tmp.ToArray());
                    tmp.Clear();
                } else
                    tmp.Add(elementSpliterator(line)
                    .Where(s => s.Trim().Length > 0)
                    .Select(converter).ToArray());
            }

            result.Add(tmp.ToArray());

            return result;
        }

        public static T[][] FileInputToMultidimensionalArray<T>(IEnumerable<string> input,
            Func<string, string[]> elementSpliterator, Func<string, T> converter)
            => input.Select(line => elementSpliterator(line)
                    .Where(s => s.Length > 0)
                    .Select(converter).ToArray()
                ).ToArray();

        public static Dictionary<K, V> ToDictionary<K, V>(string filePath, Func<string, (K, V)> spliterator)
            => ToDictionary(File.ReadAllLines(filePath), spliterator);

        public static Dictionary<K, V> ToDictionary<K, V>(IEnumerable<string> input, Func<string, (K, V)> spliterator)
            => PopulateDictionary<K, V>(input, (dictionary, line) =>
            {
                var (key, value) = spliterator(line);
                dictionary[key] = value;
            });

        public static Dictionary<K, V> SummableToDictionary<K, V>(string filePath, Func<string, (K, V)> spliterator)
            => SummableToDictionary(File.ReadAllLines(filePath), spliterator);

        public static Dictionary<K, V> SummableToDictionary<K, V>(IEnumerable<string> input,
            Func<string, (K, V)> spliterator)
            => PopulateDictionary<K, V>(input, (dictionary, line) =>
            {
                var (key, value) = spliterator(line);
                dictionary.SetOrAdd(key, value);
            });


        public static Dictionary<K, V> PopulateDictionary<K, V>(IEnumerable<string> input,
            Action<Dictionary<K, V>, string> populator)
        {
            var dictionary = new Dictionary<K, V>();

            foreach (var line in input)
                populator(dictionary, line);

            return dictionary;
        }
    }
}