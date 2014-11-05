using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Reactol
{
    [TestFixture]
    public class ReactionHandlerTests
    {
        [Test]
        public void MessageCanNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => SutFactory((Type) null));
        }

        [Test]
        public void HandlerCanNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => SutFactory((Func<object, IEnumerable<object>>)null));
        }

        [Test]
        public void MessageReturnsExpectedResult()
        {
            var sut = SutFactory(typeof (object));
            var result = sut.Message;
            Assert.That(result, Is.EqualTo(typeof(object)));
        }

        [Test]
        public void HandlerReturnsExpectedResult()
        {
            Func<object, IEnumerable<object>> handler = _ => Enumerable.Empty<object>();
            var sut = SutFactory(handler);
            var result = sut.Handler;
            Assert.That(result, Is.EqualTo(handler));
        }

        private static ReactionHandler SutFactory(Type message)
        {
            return SutFactory(message, _ => Enumerable.Empty<object>());
        }

        private static ReactionHandler SutFactory(Func<object, IEnumerable<object>> handler)
        {
            return SutFactory(typeof(object), handler);
        }

        private static ReactionHandler SutFactory(Type message, Func<object, IEnumerable<object>> handler)
        {
            return new ReactionHandler(message, handler);
        }
    }
}
