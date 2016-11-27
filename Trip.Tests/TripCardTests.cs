using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip;

namespace Trip.Tests
{
    [TestFixture]
    public class TripCardTests
    {
        [TestCase]
        public void TripCard_CtorTest()
        {
            Assert.Throws(typeof(ArgumentException), () => new TripCard(null, null));
            Assert.Throws(typeof(ArgumentException), () => new TripCard("1", null), "cityTo");
            Assert.Throws(typeof(ArgumentException), () => new TripCard(null, "1"), "cityFrom");
            Assert.Throws(typeof(ArgumentException), () => new TripCard("1", "1"));

            // Строки с пробелами
            Assert.Throws(typeof(ArgumentException), () => new TripCard("  1 ", " 1   "));
            Assert.Throws(typeof(ArgumentException), () => new TripCard("   ", " 1   "), "cityFrom");

            Assert.DoesNotThrow(() => new TripCard("1", "2"));
        }
    }
}
