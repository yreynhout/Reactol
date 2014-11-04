using System;
using System.Collections.Generic;

namespace Reactol
{
    /// <summary>
    /// Represents a message reaction handler.
    /// </summary>
    public class ReactionHandler
    {
        private readonly Type _message;
        private readonly Func<object, IEnumerable<object>> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReactionHandler"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="handler">The handler.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> or <paramref name="handler"/> is <c>null</c>.</exception>
        public ReactionHandler(Type message, Func<object, IEnumerable<object>> handler)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (handler == null) throw new ArgumentNullException("handler");
            _message = message;
            _handler = handler;
        }

        /// <summary>
        /// Gets the message type being handled by this handler.
        /// </summary>
        /// <value>
        /// The message type.
        /// </value>
        public Type Message
        {
            get { return _message; }
        }

        /// <summary>
        /// Gets the actual message handler.
        /// </summary>
        /// <value>
        /// The message handler.
        /// </value>
        public Func<object, IEnumerable<object>> Handler
        {
            get { return _handler; }
        }
    }
}