using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Tests
{
    [TestFixture]
    public class TripCardSorterTests
    {
        [TestCase]
        public void TripCardSorter_NullSequence()
        {
            Assert.Throws(typeof(ArgumentException), () => TripCardSorter.Sort(null));
        }

        [TestCase]
        public void TripCardSorter_Sorts()
        {
            TripCard[] sequence1 = new TripCard[0];
            
            TripCard[] sequence2 = new[]
            {
                new TripCard("2", "1"),
            };
            
            TripCard[] sequence3 = new[]
            {
                new TripCard("2", "1"),
                new TripCard("4", "3"),
                new TripCard("5", "4"),
                new TripCard("3", "2"),
                new TripCard("1", "0"),
            };

            TripCard[] sequence4 = new[]
            {
                new TripCard("5", "4"),
                new TripCard("4", "3"),
                new TripCard("3", "2"),
                new TripCard("2", "1"),
                new TripCard("1", "0"),
            };
            
            var result1 = TripCardSorter.Sort(sequence1);
            var result2 = TripCardSorter.Sort(sequence2);
            var result3 = TripCardSorter.Sort(sequence3);
            var result4= TripCardSorter.Sort(sequence4);

            Assert.IsTrue(IsSequenceSorted(result1));
            Assert.IsTrue(IsSequenceSorted(result2));
            Assert.IsTrue(IsSequenceSorted(result3));
            Assert.IsTrue(IsSequenceSorted(result4));
        }

        /// <summary>
        /// Проверяет, что последовательность отсортирована
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private bool IsSequenceSorted(IEnumerable<TripCard> sequence)
        {
            if (sequence.Count() < 2)
                return true;

            var enumerator = sequence.GetEnumerator();
            enumerator.MoveNext();
            var previousTo = enumerator.Current.CityTo;
            while (enumerator.MoveNext())
            {
                var curr = enumerator.Current;
                if (curr.CityFrom != previousTo)
                    return false;
                previousTo = curr.CityTo;
            }

            return true;
        }
    }
}
