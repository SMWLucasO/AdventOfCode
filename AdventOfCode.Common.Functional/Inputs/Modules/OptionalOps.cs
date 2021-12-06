using System;
using System.Collections.Generic;

namespace AdventOfCode.Common.Functional.Inputs.Modules
{
    public static class OptionalOps
    {
        public static FluentInput<O> SlidingWindow<I, T, O>(this FluentInput<I> fluent, int slidingWindowSize, Func<T, List<I>, Option<O>> operation)
            => throw new NotImplementedException();

        public static FluentInput<O> Map<I, O>(this FluentInput<I> fluent, Func<I, Option<O>> operation)
            => throw new NotImplementedException();

        public static FluentInput<O> MapPairs<I, O>(this FluentInput<I> fluent, Func<I, I, Option<O>> operation)
            => throw new NotImplementedException();

        public static FluentInput<O> MapN<I, O>(this FluentInput<I> fluent, int n, Func<List<I>, Option<O>> operation)
            => throw new NotImplementedException();
    }
}