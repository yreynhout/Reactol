using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Reactol
{
    namespace ReactionBuilderTests
    {
        [TestFixture]
        public class WithAnyInstance
        {
            [Test]
            public void DecoratedReactionCanNotBeNull()
            {
                Assert.Throws<ArgumentNullException>(() => new ReactionBuilder(null));
            }

            [Test]
            public void DecoratedReactionHandlersAreCopiedOnConstruction()
            {
                var handler1 = new ReactionHandler(typeof(object), o => Enumerable.Empty<object>());
                var handler2 = new ReactionHandler(typeof(object), o => Enumerable.Empty<object>());
                var reaction = new Reaction(new[]
                {
                    handler1,
                    handler2
                });
                var sut = new ReactionBuilder(reaction);

                var result = sut.Build();

                Assert.That(result.Handlers, Is.EquivalentTo(new[]
                {
                    handler1, handler2
                }));
            }

            [Test]
            public void WhenHandlerCanNotBeNull()
            {
                var sut = new ReactionBuilder();
                Assert.Throws<ArgumentNullException>(() => sut.When((Func<object, object>)null));
            }

            [Test]
            public void WhenArrayHandlerCanNotBeNull()
            {
                var sut = new ReactionBuilder();
                Assert.Throws<ArgumentNullException>(() => sut.When((Func<object, object[]>)null));
            }

            [Test]
            public void WhenEnumerationHandlerCanNotBeNull()
            {
                var sut = new ReactionBuilder();
                Assert.Throws<ArgumentNullException>(() => sut.When((Func<object, IEnumerable<object>>)null));
            }

            [Test]
            public void WhenHandlerReturnsExpectedResult()
            {
                var sut = new ReactionBuilder();
                Func<object, object> handler = o => null;
                var result = sut.When(handler);
                Assert.That(result, Is.InstanceOf<ReactionBuilder>());
            }

            [Test]
            public void WhenArrayHandlerReturnsExpectedResult()
            {
                var sut = new ReactionBuilder();
                Func<object, object[]> handler = o => null;
                var result = sut.When(handler);
                Assert.That(result, Is.InstanceOf<ReactionBuilder>());
            }

            [Test]
            public void WhenEnumerationHandlerReturnsExpectedResult()
            {
                var sut = new ReactionBuilder();
                Func<object, IEnumerable<object>> handler = o => null;
                var result = sut.When(handler);
                Assert.That(result, Is.InstanceOf<ReactionBuilder>());
            }
        }

        [TestFixture]
        public class WithEmptyInstance
        {
            private ReactionBuilder _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = new ReactionBuilder();
            }

            [Test]
            public void BuildReturnsExpectedResult()
            {
                var result = _sut.Build();

                Assert.That(result.Handlers, Is.Empty);
            }

            [Test]
            public void WhenHandlerIsPreservedUponBuild()
            {
                var output = new object();
                Func<object, object> handler = o => output;
                
                var result = _sut.When(handler).Build();

                Assert.That(result.Handlers, Has.Length.EqualTo(1));
                Assert.That(result.Handlers[0].Message, Is.EqualTo(typeof (object)));
                Assert.That(
                    result.Handlers.SelectMany(_ => _.Handler(null)),
                    Is.EquivalentTo(new[] { output }));
            }

            [Test]
            public void WhenArrayHandlerIsPreservedUponBuild()
            {
                var output = new object();
                Func<object, object[]> handler = o => new[] { output };

                var result = _sut.When(handler).Build();

                Assert.That(result.Handlers, Has.Length.EqualTo(1));
                Assert.That(result.Handlers[0].Message, Is.EqualTo(typeof(object)));
                Assert.That(
                    result.Handlers.SelectMany(_ => _.Handler(null)),
                    Is.EquivalentTo(new[] { output }));
            }

            [Test]
            public void WhenEnumerationHandlerIsPreservedUponBuild()
            {
                var output = new object();
                Func<object, IEnumerable<object>> handler = o => new[] { output };

                var result = _sut.When(handler).Build();

                Assert.That(result.Handlers, Has.Length.EqualTo(1));
                Assert.That(result.Handlers[0].Message, Is.EqualTo(typeof(object)));
                Assert.That(
                    result.Handlers.SelectMany(_ => _.Handler(null)),
                    Is.EquivalentTo(new[] { output }));
            }
        }

        [TestFixture]
        public class WithFilledInstance
        {
            private ReactionBuilder _sut;
            private object _output1;
            private Func<object, IEnumerable<object>> _handler1;
            private object _output2;
            private Func<object, IEnumerable<object>> _handler2;

            [SetUp]
            public void SetUp()
            {
                _output1 = new object();
                _output2 = new object();
                _handler1 = o => new[] { _output1 };
                _handler2 = o => new[] { _output2 };
                _sut = new ReactionBuilder().When(_handler1).When(_handler2);
            }

            [Test]
            public void BuildReturnsExpectedResult()
            {
                var result = _sut.Build();

                Assert.That(
                    result.Handlers.SelectMany(_ => _.Handler(null)),
                    Is.EquivalentTo(new[] { _output1, _output2 }));
            }

            [Test]
            public void WhenHandlerIsPreservedUponBuild()
            {
                var output3 = new object();
                Func<object, object> handler = o => output3;

                var result = _sut.When(handler).Build();

                Assert.That(result.Handlers, Has.Length.EqualTo(3));
                Assert.That(result.Handlers[2].Message, Is.EqualTo(typeof(object)));
                Assert.That(
                    result.Handlers.SelectMany(_ => _.Handler(null)),
                    Is.EquivalentTo(new[] { _output1, _output2, output3 }));
            }

            [Test]
            public void WhenArrayHandlerIsPreservedUponBuild()
            {
                var output3 = new object();
                Func<object, object[]> handler = o => new[] { output3 };

                var result = _sut.When(handler).Build();

                Assert.That(result.Handlers, Has.Length.EqualTo(3));
                Assert.That(result.Handlers[2].Message, Is.EqualTo(typeof(object)));
                Assert.That(
                    result.Handlers.SelectMany(_ => _.Handler(null)),
                    Is.EquivalentTo(new[] { _output1, _output2, output3 }));
            }

            [Test]
            public void WhenEnumerationHandlerIsPreservedUponBuild()
            {
                var output3 = new object();
                Func<object, IEnumerable<object>> handler = o => new[] { output3 };

                var result = _sut.When(handler).Build();

                Assert.That(result.Handlers, Has.Length.EqualTo(3));
                Assert.That(result.Handlers[2].Message, Is.EqualTo(typeof(object)));
                Assert.That(
                    result.Handlers.SelectMany(_ => _.Handler(null)),
                    Is.EquivalentTo(new[] { _output1, _output2, output3 }));
            }
        }
    }
}
