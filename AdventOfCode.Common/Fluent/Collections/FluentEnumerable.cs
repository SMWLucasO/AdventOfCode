using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common.Fluent.Collections
{
    public static class FluentEnumerable
    {
        public static void ForEachVertical<T, V>(this IEnumerable<T> enumerable, int column, Action<V> action)
            where T : IEnumerable
        {
            var indexer = typeof(T).GetProperties()
                .FirstOrDefault(t => t.GetIndexParameters().Length != 0);

            if (indexer == null)
                throw new InvalidOperationException("Cannot vertically iterate over non-indexable elements.");


            foreach (var element in enumerable)
            {
                var expectedValue = (V) indexer.GetValue(element, new object[] {column});
                action(expectedValue);
            }
        }
        
        public static IEnumerable<T> Then<T>(this IEnumerable<T> collection, Action<T> operation)
        {
            foreach (var el in collection) 
                operation(el);

            return collection;
        }
        
    }
}