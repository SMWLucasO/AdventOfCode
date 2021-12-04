using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common.Fluent.Collections
{
    public static class FluentDictionary
    {
        public static void SetOrAdd<K, V>(this Dictionary<K, V> dictionary, K key, V value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary[key] = (dynamic) dictionary[key] + (dynamic) value;
        }

    }
}