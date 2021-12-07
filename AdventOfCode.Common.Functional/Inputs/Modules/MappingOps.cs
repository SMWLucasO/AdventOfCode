using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common.Functional.Inputs.Modules
{
    public record FluentNullable<E>(E Element);

    public static class MappingOps
    {
        public static FluentInput<O> MapPairs<I, O>(this FluentInput<I> fluent, Func<I, I, O> operation)
            => throw new NotImplementedException();


        // Calculation, condition funcs should be separated.
        public static FluentInput<O> SlideNWithPrevOutput<I, O>(this FluentInput<I> fluent,
            Func<List<I>, O> handleInitial, Func<O, List<I>, O> op)
        {
            throw new NotImplementedException();
        }


        public static FluentInput<O> MapN<I, O>(this FluentInput<I> fluent, int n, Func<List<I>, O> operation)
            => throw new NotImplementedException();
    }
}