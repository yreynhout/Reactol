using System;
using NUnit.Framework;

namespace Reactol
{
    [TestFixture]
    public class ReactorTests
    {
        [Test]
        public void ReactionCanNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Reactor(null));
        }

        [Test]
        public void ReactToMessageCanNotBeNull()
        {
            var sut = new Reactor(Reaction.Empty);
            Assert.Throws<ArgumentNullException>(() => sut.ReactTo(null));
        }

        [Test]
        public void ReactToReturnsExpectedResult()
        {
            var output1 = new object();
            var output2 = new object();
            var sut = new Reactor(
                new ReactionBuilder().
                    When<object>(message => output1).
                    When<int>(message => output2).
                    Build());
            var result = sut.ReactTo(new object());
            Assert.That(result, Is.EquivalentTo(new[] {output1}));
        }
    }
}
