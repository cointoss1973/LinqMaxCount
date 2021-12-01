using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LinqMaxCount
{
    public static class LinqExtensions
    {
        /// <summary>
        /// MaxCount Implement 1
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static int MaxCount1(this IEnumerable<int> input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (!input.Any()) throw new ArgumentException("Empty list", nameof(input));

            var result = input.GroupBy(x => x)
                .Select(x => new { Value = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .First()
                .Value;

            return result;
        }

        /// <summary>
        /// MaxCount Implement 2
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static int MaxCount2(this IEnumerable<int> input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (!input.Any()) throw new ArgumentException("Empty list", nameof(input));

            var uniqInput = input.Distinct();
            var histogram = uniqInput.Zip(uniqInput.Select(x => input.Count(y => x == y)), (x, y) => new { Item = x, Count = y });
            var max = histogram.Aggregate((candidate, next) => next.Count > candidate.Count ? next : candidate);

            return max.Item;
        }


        /// <summary>
        /// MaxCount Implement 3 (Using ToLookup)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static int MaxCount3(this IEnumerable<int> input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (!input.Any()) throw new ArgumentException("Empty list", nameof(input));

            var list = input.ToLookup(i => i).Select(n => new { n.Key, Count = n.Count() });
            var result = list.OrderByDescending(x => x.Count).First().Key;
            return result;
        }
    }





    /// <summary>
    /// Unit Test
    /// </summary>
    public class LinqExtensionsUnitTest
    {
        public static IEnumerable<object[]> TestData => new List<object[]>()
        {
            // expected, input 
            new object[] {1, new int[] { 1, 5, 8, 3, 6, 1, 2, 5, 4, 1, 1, 4, 8, 1 } },
            new object[] {2, new int[] { 0, 1, 2, 3, 3, 2} },
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void TestMaxCount1(int expected, int[] input)
        {
            var actual = input.MaxCount1();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void TestMaxCount2(int expected, int[] input)
        {
            var actual = input.MaxCount2();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void TestMaxCount3(int expected, int[] input)
        {
            var actual = input.MaxCount3();
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// MoreLinq CountBy
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="input"></param>
        [Theory]
        [MemberData(nameof(TestData))]
        public void TestMoreLinqCountBy(int expected, int[] input)
        {
            var sortList = input.CountBy(i => i).OrderByDescending(n => n.Value);
            var actual = sortList.First().Key;
            Assert.Equal(expected, actual);
        }
    }
}