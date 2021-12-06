using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common.Functional.Inputs.Modules
{
    public static class OptionalOps
    {
        public static FluentInput<O> MapSlidingWindow<I, O>(this FluentInput<I> fluent, int slidingWindowSize,
            Func<List<I>, Option<O>> operation)
        {
            if (slidingWindowSize > fluent.Elements.Count)
                throw new InvalidOperationException(
                    $"Cannot slide a window outside of the range: [0, {fluent.Elements.Count}]");

            FluentInput<O> output = new();
            LinkedList<I> tmp = new();

            foreach (var element in fluent.Elements)
            {
                tmp.AddLast(element);

                if (tmp.Count < slidingWindowSize)
                    continue;

                var res = operation(tmp.ToList());
                if (res.Pass)
                    output.Elements.Add(res.element);

                tmp.RemoveFirst();
            }

            return output;
        }

        public static FluentInput<O> Map<I, O>(this FluentInput<I> fluent, Func<I, Option<O>> operation)
            => new() {Elements = fluent.Elements.Select(operation).Where(x => x.Pass).Select(x => x.element).ToList()};

        public static FluentInput<O> MapPairs<I, O>(this FluentInput<I> fluent, Func<I, I, Option<O>> operation)
            => throw new NotImplementedException();

        public static FluentInput<O> MapN<I, O>(this FluentInput<I> fluent, int n, Func<List<I>, Option<O>> operation)
            => throw new NotImplementedException();
    }
}