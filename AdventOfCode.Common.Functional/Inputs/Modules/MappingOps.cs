﻿using System;
using System.Collections.Generic;

namespace AdventOfCode.Common.Functional.Inputs.Modules
{
    public static class MappingOps
    {
        public static FluentInput<O> MapPairs<I, O>(this FluentInput<I> fluent, Func<I, I, O> operation)
            => throw new NotImplementedException();

        public static FluentInput<O> MapN<I, O>(this FluentInput<I> fluent, int n, Func<List<I>, O> operation)
            => throw new NotImplementedException();
    }
}