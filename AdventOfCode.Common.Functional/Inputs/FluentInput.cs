using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common.Functional.Inputs
{
    public record Option<E>(E element, bool Pass = true);

    public class FluentInput<I>
    {
        public ICollection<I> Elements { get; set; }
            = new List<I>();

        public static FluentInput<I> From(ICollection<I> input)
            => new() {Elements = input};

        // T = previous output, List<i> = current elements in window, operation = operation obv.
        public FluentInput<O> MapSlidingWindow<O>(int slidingWindowSize, Func<List<I>, O> operation)
        {
            if (slidingWindowSize > Elements.Count)
                throw new InvalidOperationException(
                    $"Cannot slide a window outside of the range: [0, {Elements.Count}]");

            FluentInput<O> output = new();
            LinkedList<I> tmp = new();

            foreach (var element in Elements)
            {
                tmp.AddLast(element);

                if (tmp.Count < slidingWindowSize)
                    continue;

                var res = operation(tmp.ToList());
                output.Elements.Add(res);

                tmp.RemoveFirst();
            }

            return output;
        }

        public FluentInput<O> Map<O>(Func<I, O> operation)
            => new() {Elements = Elements.Select(operation).ToList()};

        public FluentInput<I> Filter(Predicate<I> operation)
            => new() {Elements = Elements.Where(x => operation(x)).ToList()};
    }
}