using System;
using System.Collections.Generic;
using System.Linq;

namespace Reactol
{
    /// <summary>
    ///   Represents a composition of reaction messages.
    /// </summary>
    public class ReactionComposer
    {
        private readonly object[] _messages;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReactionComposer" /> class.
        /// </summary>
        public ReactionComposer()
        {
            _messages = new object[0];
        }

        ReactionComposer(object[] messages)
        {
            _messages = messages;
        }

        /// <summary>
        /// Gets the collected reaction messages.
        /// </summary>
        public object[] Messages
        {
            get { return _messages; }
        }

        /// <summary>
        ///     Composes this instance with the specified <paramref name="message" />.
        /// </summary>
        /// <param name="message">The <see cref="object">message</see> to compose with.</param>
        /// <returns>A new composition of <see cref="object">messages</see>.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the <paramref name="message" /> is <c>null</c>.</exception>
        public ReactionComposer Compose(object message)
        {
            if (message == null) throw new ArgumentNullException("message");
            return new ReactionComposer(Messages.Concat(new[] { message}).ToArray());
        }

        /// <summary>
        ///     Composes this instance with the specified <paramref name="messages" />.
        /// </summary>
        /// <param name="messages">The <see cref="object">messages</see> to compose with.</param>
        /// <returns>A new composition of <see cref="object">messages</see>.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the <paramref name="messages" /> are <c>null</c>.</exception>
        public ReactionComposer Compose(object[] messages)
        {
            if (messages == null) throw new ArgumentNullException("messages");
            return new ReactionComposer(Messages.Concat(messages).ToArray());
        }

        /// <summary>
        ///     Composes this instance with the specified <paramref name="messages" />.
        /// </summary>
        /// <param name="messages">The <see cref="object">messages</see> to compose with.</param>
        /// <returns>A new composition of <see cref="object">messages</see>.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the <paramref name="messages" /> are <c>null</c>.</exception>
        public ReactionComposer Compose(IEnumerable<object> messages)
        {
            if (messages == null) throw new ArgumentNullException("messages");
            return new ReactionComposer(Messages.Concat(messages).ToArray());
        }
        
        /// <summary>
        ///     Composes this instance with the specified <paramref name="message" /> if the condition is satisfied.
        /// </summary>
        /// <param name="condition">The condition to satisfy.</param>
        /// <param name="message">The <see cref="object">message</see> to compose with.</param>
        /// <returns>A new composition of <see cref="object">messages</see>.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the <paramref name="message" /> is <c>null</c>.</exception>
        public ReactionComposer ComposeIf(bool condition, object message)
        {
            if (message == null) throw new ArgumentNullException("message");
            return condition ? Compose(message) : this;
        }

        /// <summary>
        ///     Composes this instance with the specified <paramref name="messages" /> if the condition is satisfied.
        /// </summary>
        /// <param name="condition">The condition to satisfy.</param>
        /// <param name="messages">The <see cref="object">messages</see> to compose with.</param>
        /// <returns>A new composition of <see cref="object">messages</see>.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the <paramref name="messages" /> are <c>null</c>.</exception>
        public ReactionComposer ComposeIf(bool condition, object[] messages)
        {
            if (messages == null) throw new ArgumentNullException("messages");
            return condition ? Compose(messages) : this;
        }

        /// <summary>
        ///     Composes this instance with the specified <paramref name="messages" /> if the condition is satisfied.
        /// </summary>
        /// <param name="condition">The condition to satisfy.</param>
        /// <param name="messages">The <see cref="object">messages</see> to compose with.</param>
        /// <returns>A new composition of <see cref="object">messages</see>.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the <paramref name="messages" /> are <c>null</c>.</exception>
        public ReactionComposer ComposeIf(bool condition, IEnumerable<object> messages)
        {
            if (messages == null) throw new ArgumentNullException("messages");
            return condition ? Compose(messages) : this;
        }

        /// <summary>
        ///     Composes this instance with the specified <paramref name="message" /> unless the condition is satisfied.
        /// </summary>
        /// <param name="condition">The condition to satisfy.</param>
        /// <param name="message">The <see cref="object">message</see> to compose with.</param>
        /// <returns>A new composition of <see cref="object">messages</see>.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the <paramref name="message" /> is <c>null</c>.</exception>
        public ReactionComposer ComposeUnless(bool condition, object message)
        {
            if (message == null) throw new ArgumentNullException("message");
            return !condition ? Compose(message) : this;
        }

        /// <summary>
        ///     Composes this instance with the specified <paramref name="messages" /> unless the condition is satisfied.
        /// </summary>
        /// <param name="condition">The condition to satisfy.</param>
        /// <param name="messages">The <see cref="object">messages</see> to compose with.</param>
        /// <returns>A new composition of <see cref="object">messages</see>.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the <paramref name="messages" /> are <c>null</c>.</exception>
        public ReactionComposer ComposeUnless(bool condition, object[] messages)
        {
            if (messages == null) throw new ArgumentNullException("messages");
            return !condition ? Compose(messages) : this;
        }

        /// <summary>
        ///     Composes this instance with the specified <paramref name="messages" /> unless the condition is satisfied.
        /// </summary>
        /// <param name="condition">The condition to satisfy.</param>
        /// <param name="messages">The <see cref="object">messages</see> to compose with.</param>
        /// <returns>A new composition of <see cref="object">messages</see>.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the <paramref name="messages" /> are <c>null</c>.</exception>
        public ReactionComposer ComposeUnless(bool condition, IEnumerable<object> messages)
        {
            if (messages == null) throw new ArgumentNullException("messages");
            return !condition ? Compose(messages) : this;
        }

        /// <summary>
        ///     Implicitly converts a composition of <see cref="object">messages</see> to an array of
        ///     <see cref="object">messages</see>.
        /// </summary>
        /// <param name="instance">The instance to convert.</param>
        /// <returns>An array of <see cref="object">messages</see>.</returns>
        public static implicit operator object[](ReactionComposer instance)
        {
            if (instance == null) throw new ArgumentNullException("instance");
            return instance.Messages;
        }
    }
}