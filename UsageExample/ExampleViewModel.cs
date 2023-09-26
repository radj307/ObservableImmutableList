using radj307.ObservableImmutableList;
using System;

namespace UsageExample
{
    public class ExampleViewModel
    {
        public ExampleViewModel()
        {
            Items = new();

            // create a random number of objects with random values
            var rng = new Random();
            for (int i = 0, max = rng.Next(10, 100); i < max; ++i)
            {
                Items.Add(new ExampleObject(rng));
            }
        }

        public ObservableImmutableList<ExampleObject> Items { get; }
    }
}
