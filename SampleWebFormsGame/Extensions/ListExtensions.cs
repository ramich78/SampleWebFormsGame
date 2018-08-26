using System;
using System.Collections.Generic;

namespace SampleWebFormsGame.Extensions
{
    static class ListExtensions
    {
        private static readonly Random RandomGen = new Random();

        //Fisher-Yates shuffle algorithm
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            IList<T> result = new List<T>(list);

            int n = result.Count;
            while (n > 1)
            {
                n--;
                int k = RandomGen.Next(n + 1);
                T value = result[k];
                result[k] = result[n];
                result[n] = value;
            }

            return result;
        }
    }
}