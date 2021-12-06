using System;
using System.Collections.Generic;

namespace AdventOfCode.Common.Functional.Inputs.Modules
{
    public static class FilterOps
    {
        public static FluentInput<I> FilterPair<I>(this FluentInput<I> fluent, Func<I, I, bool> operation,
            Predicate<I> remainderOperation = null)
        {
            FluentInput<I> output = new();
            List<I> args = new();

            foreach (var el in fluent.Elements)
            {
                args.Add(el);

                if (args.Count != 2)
                    continue;

                if (operation(args[0], args[1]))
                {
                    output.Elements.Add(args[0]);
                    output.Elements.Add(args[1]);
                    args.Clear();
                }
            }

            if (args.Count == 0) return output;

            if (remainderOperation != null && remainderOperation(args[0]))
                output.Elements.Add(args[0]);
            else if (remainderOperation == null && operation(args[0], default))
                output.Elements.Add(args[0]);


            return output;
        }

        public static FluentInput<I> FilterN<I>(this FluentInput<I> fluent, int elementsPerTime,
            Func<List<I>, bool> operation,
            Predicate<List<I>> remainderOperation = null)
        {
            if (elementsPerTime < 1)
                return fluent;

            FluentInput<I> output = new();
            List<I> args = new();

            foreach (var el in fluent.Elements)
            {
                args.Add(el);

                if (args.Count != elementsPerTime)
                    continue;

                if (operation(args))
                {
                    args.ForEach(x => output.Elements.Add(x));
                    args.Clear();
                }
            }

            if (args.Count == 0) return output;

            if (remainderOperation != null && remainderOperation(args))
                args.ForEach(x => output.Elements.Add(x));
            else if (remainderOperation == null && operation(args))
                args.ForEach(x => output.Elements.Add(x));


            return output;
        }
    }
}