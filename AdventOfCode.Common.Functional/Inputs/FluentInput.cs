﻿using System;
using System.Collections.Generic;

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
        public FluentInput<O> SlidingWindow<T, O>(int slidingWindowSize, Func<T, List<I>, O> operation)
            => throw new NotImplementedException();

        public FluentInput<O> Map<O>(Func<I, O> operation)
            => throw new NotImplementedException();

        public FluentInput<O> MapPairs<O>(Func<I, I, O> operation)
            => throw new NotImplementedException();

        public FluentInput<O> MapN<O>(int n, Func<List<I>, O> operation)
            => throw new NotImplementedException();

        public FluentInput<I> Filter(Predicate<I> operation)
            => throw new NotImplementedException();

        public FluentInput<I> FilterPair(Func<I, I, bool> operation)
            => throw new NotImplementedException();

        public FluentInput<I> FilterN(Func<List<I>, bool> operation)
            => throw new NotImplementedException();

        public FluentInput<O> Flatten<O>()
            => throw new NotImplementedException();
    }
}