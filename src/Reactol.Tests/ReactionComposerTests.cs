using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Reactol
{
    namespace ReactionComposerTests
    {
        [TestFixture]
        public class WithAnyInstance
        {
            private ReactionComposer _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = new ReactionComposer().
                    Compose(
                        Enumerable.Repeat(
                            new object(),
                            new Random().Next(0, 10)));
            }

            [Test]
            public void ImplicitConversionOfNullThrows()
            {
                Assert.Throws<ArgumentNullException>(() => { object[] _ = (ReactionComposer) null; });
            }

            [Test]
            public void ExplicitConversionOfNullThrows()
            {
                Assert.Throws<ArgumentNullException>(() => { var _ = (object[])(ReactionComposer)null; });
            }

            [Test]
            public void ComposeMessageCanNotBeNull()
            {
                Assert.Throws<ArgumentNullException>(() => _sut.Compose((object) null));
            }

            [Test]
            public void ComposeMessageArrayCanNotBeNull()
            {
                Assert.Throws<ArgumentNullException>(() => _sut.Compose((object[])null));
            }

            [Test]
            public void ComposeMessageEnumerationCanNotBeNull()
            {
                Assert.Throws<ArgumentNullException>(() => _sut.Compose((IEnumerable<object>)null));
            }

            [TestCase(true)]
            [TestCase(false)]
            public void ComposeIfMessageCanNotBeNull(bool condition)
            {
                Assert.Throws<ArgumentNullException>(() => _sut.ComposeIf(condition, (object)null));
            }

            [TestCase(true)]
            [TestCase(false)]
            public void ComposeIfMessageArrayCanNotBeNull(bool condition)
            {
                Assert.Throws<ArgumentNullException>(() => _sut.ComposeIf(condition, (object[])null));
            }

            [TestCase(true)]
            [TestCase(false)]
            public void ComposeIfMessageEnumerationCanNotBeNull(bool condition)
            {
                Assert.Throws<ArgumentNullException>(() => _sut.ComposeIf(condition, (IEnumerable<object>)null));
            }

            [TestCase(true)]
            [TestCase(false)]
            public void ComposeUnlessMessageCanNotBeNull(bool condition)
            {
                Assert.Throws<ArgumentNullException>(() => _sut.ComposeUnless(condition, (object)null));
            }

            [TestCase(true)]
            [TestCase(false)]
            public void ComposeUnlessMessageArrayCanNotBeNull(bool condition)
            {
                Assert.Throws<ArgumentNullException>(() => _sut.ComposeUnless(condition, (object[])null));
            }

            [TestCase(true)]
            [TestCase(false)]
            public void ComposeUnlessMessageEnumerationCanNotBeNull(bool condition)
            {
                Assert.Throws<ArgumentNullException>(() => _sut.ComposeUnless(condition, (IEnumerable<object>)null));
            }
        }

        [TestFixture]
        public class WithEmptyInstance
        {
            private ReactionComposer _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = new ReactionComposer();
            }

            [Test]
            public void MessagesReturnsExpectedResult()
            {
                Assert.That(_sut.Messages, Is.Empty);
            }

            [Test]
            public void ImplicitConversionToObjectArrayReturnsExpectedResult()
            {
                object[] result = _sut;
                Assert.That(result, Is.Empty);
            }

            [Test]
            public void ExplicitConversionToObjectArrayReturnsExpectedResult()
            {
                var result = (object[])_sut;
                Assert.That(result, Is.Empty);
            }

            [Test]
            public void ComposeMessageReturnsExpectedResult()
            {
                var message = new object();
                var result = _sut.Compose(message).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { message }));
            }

            [Test]
            public void ComposeMessageArrayReturnsExpectedResult()
            {
                var messages = new [] { new object() };
                var result = _sut.Compose(messages).Messages;
                Assert.That(result, Is.EquivalentTo(messages));
            }

            [Test]
            public void ComposeMessageEnumerationReturnsExpectedResult()
            {
                var messages = new[] { new object() };
                var result = _sut.Compose((IEnumerable<object>)messages).Messages;
                Assert.That(result, Is.EquivalentTo(messages));
            }

            [Test]
            public void ComposeIfMessageReturnsExpectedResultWhenConditionIsSatisfied()
            {
                var message = new object();
                var result = _sut.ComposeIf(true, message).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { message }));
            }

            [Test]
            public void ComposeIfMessageArrayReturnsExpectedResultWhenConditionIsSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeIf(true, messages).Messages;
                Assert.That(result, Is.EquivalentTo(messages));
            }

            [Test]
            public void ComposeIfMessageEnumerationReturnsExpectedResultWhenConditionIsSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeIf(true, (IEnumerable<object>)messages).Messages;
                Assert.That(result, Is.EquivalentTo(messages));
            }

            [Test]
            public void ComposeIfMessageReturnsExpectedResultWhenConditionIsNotSatisfied()
            {
                var message = new object();
                var result = _sut.ComposeIf(false, message).Messages;
                Assert.That(result, Is.Empty);
            }

            [Test]
            public void ComposeIfMessageArrayReturnsExpectedResultWhenConditionIsNotSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeIf(false, messages).Messages;
                Assert.That(result, Is.Empty);
            }

            [Test]
            public void ComposeIfMessageEnumerationReturnsExpectedResultWhenConditionIsNotSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeIf(false, (IEnumerable<object>)messages).Messages;
                Assert.That(result, Is.Empty);
            }

            [Test]
            public void ComposeUnlessMessageReturnsExpectedResultWhenConditionIsSatisfied()
            {
                var message = new object();
                var result = _sut.ComposeUnless(true, message).Messages;
                Assert.That(result, Is.Empty);
            }

            [Test]
            public void ComposeUnlessMessageArrayReturnsExpectedResultWhenConditionIsSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeUnless(true, messages).Messages;
                Assert.That(result, Is.Empty);
            }

            [Test]
            public void ComposeUnlessMessageEnumerationReturnsExpectedResultWhenConditionIsSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeUnless(true, (IEnumerable<object>)messages).Messages;
                Assert.That(result, Is.Empty);
            }

            [Test]
            public void ComposeUnlessMessageReturnsExpectedResultWhenConditionIsNotSatisfied()
            {
                var message = new object();
                var result = _sut.ComposeUnless(false, message).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { message }));
            }

            [Test]
            public void ComposeUnlessMessageArrayReturnsExpectedResultWhenConditionIsNotSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeUnless(false, messages).Messages;
                Assert.That(result, Is.EquivalentTo(messages));
            }

            [Test]
            public void ComposeUnlessMessageEnumerationReturnsExpectedResultWhenConditionIsNotSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeUnless(false, (IEnumerable<object>)messages).Messages;
                Assert.That(result, Is.EquivalentTo(messages));
            }
        }

        [TestFixture]
        public class WithFilledInstance
        {
            private object _message;
            private ReactionComposer _sut;

            [SetUp]
            public void SetUp()
            {
                _message = new object();
                _sut = new ReactionComposer().Compose(_message);
            }

            [Test]
            public void MessagesReturnsExpectedResult()
            {
                Assert.That(_sut.Messages, Is.EquivalentTo(new[] { _message }));
            }

            [Test]
            public void ImplicitConversionToObjectArrayReturnsExpectedResult()
            {
                object[] result = _sut;
                Assert.That(result, Is.EquivalentTo(new[] { _message }));
            }

            [Test]
            public void ExplicitConversionToObjectArrayReturnsExpectedResult()
            {
                var result = (object[])_sut;
                Assert.That(result, Is.EquivalentTo(new[] { _message }));
            }

            [Test]
            public void ComposeMessageReturnsExpectedResult()
            {
                var message = new object();
                var result = _sut.Compose(message).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message, message }));
            }

            [Test]
            public void ComposeMessageArrayReturnsExpectedResult()
            {
                var messages = new[] { new object() };
                var result = _sut.Compose(messages).Messages;
                Assert.That(result, Is.EquivalentTo(new[] {_message}.Concat(messages)));
            }

            [Test]
            public void ComposeMessageEnumerationReturnsExpectedResult()
            {
                var messages = new[] { new object() };
                var result = _sut.Compose((IEnumerable<object>)messages).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message }.Concat(messages)));
            }

            [Test]
            public void ComposeIfMessageReturnsExpectedResultWhenConditionIsSatisfied()
            {
                var message = new object();
                var result = _sut.ComposeIf(true, message).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message, message }));
            }

            [Test]
            public void ComposeIfMessageArrayReturnsExpectedResultWhenConditionIsSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeIf(true, messages).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message }.Concat(messages)));
            }

            [Test]
            public void ComposeIfMessageEnumerationReturnsExpectedResultWhenConditionIsSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeIf(true, (IEnumerable<object>)messages).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message }.Concat(messages)));
            }

            [Test]
            public void ComposeIfMessageReturnsExpectedResultWhenConditionIsNotSatisfied()
            {
                var message = new object();
                var result = _sut.ComposeIf(false, message).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message }));
            }

            [Test]
            public void ComposeIfMessageArrayReturnsExpectedResultWhenConditionIsNotSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeIf(false, messages).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message }));
            }

            [Test]
            public void ComposeIfMessageEnumerationReturnsExpectedResultWhenConditionIsNotSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeIf(false, (IEnumerable<object>)messages).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message }));
            }

            [Test]
            public void ComposeUnlessMessageReturnsExpectedResultWhenConditionIsSatisfied()
            {
                var message = new object();
                var result = _sut.ComposeUnless(true, message).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message }));
            }

            [Test]
            public void ComposeUnlessMessageArrayReturnsExpectedResultWhenConditionIsSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeUnless(true, messages).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message }));
            }

            [Test]
            public void ComposeUnlessMessageEnumerationReturnsExpectedResultWhenConditionIsSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeUnless(true, (IEnumerable<object>)messages).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message }));
            }

            [Test]
            public void ComposeUnlessMessageReturnsExpectedResultWhenConditionIsNotSatisfied()
            {
                var message = new object();
                var result = _sut.ComposeUnless(false, message).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message, message }));
            }

            [Test]
            public void ComposeUnlessMessageArrayReturnsExpectedResultWhenConditionIsNotSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeUnless(false, messages).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message }.Concat(messages)));
            }

            [Test]
            public void ComposeUnlessMessageEnumerationReturnsExpectedResultWhenConditionIsNotSatisfied()
            {
                var messages = new[] { new object() };
                var result = _sut.ComposeUnless(false, (IEnumerable<object>)messages).Messages;
                Assert.That(result, Is.EquivalentTo(new[] { _message }.Concat(messages)));
            }
        }
    }
}
