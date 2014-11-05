using System;
using System.Collections.Generic;
using System.Linq;

namespace Reactol
{
    /// <summary>
    ///     Represents a fluent syntax to build up a <see cref="Reaction" />.
    /// </summary>
    public class ReactionBuilder
    {
        private readonly ReactionHandler[] _handlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReactionBuilder"/> class.
        /// </summary>
        public ReactionBuilder()
        {
            _handlers = new ReactionHandler[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReactionBuilder"/> class.
        /// </summary>
        /// <param name="reaction">The reaction.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="reaction"/> is <c>null</c>.</exception>
        public ReactionBuilder(Reaction reaction)
        {
            if (reaction == null) throw new ArgumentNullException("reaction");
            _handlers = reaction.Handlers;
        }

        ReactionBuilder(ReactionHandler[] handlers)
        {
            _handlers = handlers;
        }

        /// <summary>
        ///     Specifies the message returning handler to be invoked when a particular message occurs.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="handler">The message returning handler.</param>
        /// <returns>A <see cref="ReactionBuilder" />.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="handler" /> is <c>null</c>.</exception>
        public ReactionBuilder When<TMessage>(Func<TMessage, object> handler)
        {
            if (handler == null) throw new ArgumentNullException("handler");
            return new ReactionBuilder(
                _handlers.
                    Concat(new[]
                    {
                        new ReactionHandler(
                            typeof (TMessage),
                            message => new [] {handler((TMessage) message)})
                    }).
                    ToArray());
        }

        /// <summary>
        ///     Specifies the message enumeration returning handler to be invoked when a particular message occurs.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="handler">The message enumeration returning handler.</param>
        /// <returns>A <see cref="ReactionBuilder" />.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="handler" /> is <c>null</c>.</exception>
        public ReactionBuilder When<TMessage>(Func<TMessage, object[]> handler)
        {
            if (handler == null) throw new ArgumentNullException("handler");
            return new ReactionBuilder(
                _handlers.
                    Concat(new[]
                    {
                        new ReactionHandler(
                            typeof (TMessage),
                            message => handler((TMessage) message))
                    }).
                    ToArray());
        }

        /// <summary>
        ///     Specifies the message enumeration returning handler to be invoked when a particular message occurs.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="handler">The message enumeration returning handler.</param>
        /// <returns>A <see cref="ReactionBuilder" />.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="handler" /> is <c>null</c>.</exception>
        public ReactionBuilder When<TMessage>(Func<TMessage, IEnumerable<object>> handler)
        {
            if (handler == null) throw new ArgumentNullException("handler");
            return new ReactionBuilder(
                _handlers.
                    Concat(new[]
                    {
                        new ReactionHandler(
                            typeof (TMessage),
                            message => handler((TMessage) message))
                    }).
                    ToArray());
        }

        /// <summary>
        ///     Builds a reaction based on the handlers collected by this builder.
        /// </summary>
        /// <returns>A <see cref="Reaction" />.</returns>
        public Reaction Build()
        {
            return new Reaction(_handlers);
        }
    }
}
