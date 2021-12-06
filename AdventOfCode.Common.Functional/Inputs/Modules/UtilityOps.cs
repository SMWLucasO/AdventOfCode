using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common.Functional.Inputs.Modules
{
    public static class UtilityOps
    {

        public static FluentInput<O> Flatten<I, O>(this FluentInput<I> fluent) where I: IEnumerable<O>
            => new() { Elements = fluent.Elements.SelectMany(x => x).ToList() };

    }
}