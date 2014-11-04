using System;
using System.Linq;
using NUnit.Framework;

namespace Reactol.UnitTests
{
    [TestFixture]
    public class ReactionTests
    {
        [Test]
        public void HandlersCanNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Reaction(null));
        }

        [Test]
        public void HandlersReturnsExpectedResult()
        {
            var handler1 = new ReactionHandler(typeof (Int32), _ => Enumerable.Empty<object>());
            var handler2 = new ReactionHandler(typeof (Int64), _ => Enumerable.Empty<object>());
            var sut = new Reaction(new[]
            {
                handler1,
                handler2
            });
            var result = sut.Handlers;
            Assert.That(result, Is.EquivalentTo(new [] { handler1, handler2}));
        }

        [Test]
        public void EmptyReturnsExpectedInstance()
        {
            var result = Reaction.Empty;

            Assert.That(result, Is.InstanceOf<Reaction>());
            Assert.That(result.Handlers, Is.Empty);
        }

        [Test]
        public void EmptyReturnsSameInstance()
        {
            Assert.AreSame(Reaction.Empty, Reaction.Empty);
        }

        [Test]
        public void ConcatReactionCanNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => Reaction.Empty.Concat((Reaction)null));
        }

        [Test]
        public void ConcatHandlerCanNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => Reaction.Empty.Concat((ReactionHandler)null));
        }

        [Test]
        public void ConcatHandlersCanNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => Reaction.Empty.Concat((ReactionHandler[])null));
        }

        [Test]
        public void ConcatReactionReturnsExpectedResult()
        {
            var handler1 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var handler2 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var handler3 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var handler4 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var projection = new Reaction(new[]
            {
                handler3,
                handler4
            });
            var sut = new Reaction(new[]
            {
                handler1,
                handler2
            });

            var result = sut.Concat(projection);

            Assert.That(result.Handlers, Is.EquivalentTo(new[] { handler1, handler2, handler3, handler4 }));
        }

        [Test]
        public void ConcatHandlerReturnsExpectedResult()
        {
            var handler1 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var handler2 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var handler3 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var sut = new Reaction(new[]
            {
                handler1,
                handler2
            });

            var result = sut.Concat(handler3);

            Assert.That(result.Handlers, Is.EquivalentTo(new[] { handler1, handler2, handler3 }));
        }

        [Test]
        public void ConcatHandlersReturnsExpectedResult()
        {
            var handler1 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var handler2 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var handler3 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var handler4 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var sut = new Reaction(new[]
            {
                handler1,
                handler2
            });

            var result = sut.Concat(new[]
            {
                handler3,
                handler4
            });

            Assert.That(result.Handlers, Is.EquivalentTo(new[] { handler1, handler2, handler3, handler4 }));
        }

        //[Test]
        //public void EmptyToBuilderReturnsExpectedResult()
        //{
        //    var sut = Reaction.Empty;

        //    var result = sut.ToBuilder().Build().Handlers;

        //    Assert.That(result, Is.Empty);
        //}

        //[Test]
        //public void ToBuilderReturnsExpectedResult()
        //{
        //    var handler1 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
        //    var handler2 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
        //    var sut = new Reaction(new[]
        //    {
        //        handler1,
        //        handler2
        //    });

        //    var result = sut.ToBuilder().Build().Handlers;

        //    Assert.That(result, Is.EquivalentTo(new[]
        //    {
        //        handler1,
        //        handler2
        //    }));
        //}

        [Test]
        public void ConversionOfNullToReactionHandlerArrayThrows()
        {
            Assert.Throws<ArgumentNullException>(() => { ReactionHandler[] _ = (Reaction)null; });
        }

        [Test]
        public void ImplicitConversionToReactionHandlerArray()
        {
            var handler1 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var handler2 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());

            var handlers = new[]
            {
                handler1,
                handler2
            };

            var sut = new Reaction(handlers);

            ReactionHandler[] result = sut;

            Assert.That(result, Is.EquivalentTo(handlers));
        }

        [Test]
        public void ExplicitConversionToReactionHandlerArray()
        {
            var handler1 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());
            var handler2 = new ReactionHandler(typeof(object), _ => Enumerable.Empty<object>());

            var handlers = new[]
            {
                handler1,
                handler2
            };

            var sut = new Reaction(handlers);

            var result = (ReactionHandler[])sut;

            Assert.That(result, Is.EquivalentTo(handlers));
        }
    }
}