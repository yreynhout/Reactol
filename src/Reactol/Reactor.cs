using System;
using System.Collections.Generic;
using System.Linq;

namespace Reactol
{
    /// <summary>
    /// Represents the execution of a message reaction.
    /// </summary>
    public class Reactor
    {
        private readonly Dictionary<Type, ReactionHandler[]> _handlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="Reactor"/> class.
        /// </summary>
        /// <param name="reaction">The reaction.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="reaction"/> is <c>null</c>.</exception>
        public Reactor(Reaction reaction)
        {
            if (reaction == null) throw new ArgumentNullException("reaction");
            _handlers = reaction.Handlers.
                GroupBy(handler => handler.Message).
                ToDictionary(@group => @group.Key, @group => @group.ToArray());
        }

        /// <summary>
        /// Reacts to a message and returns the resulting messages.
        /// </summary>
        /// <param name="message">The message to react to.</param>
        /// <returns>A collection of <see cref="object">messages</see>.</returns>
        public IEnumerable<object> ReactTo(object message)
        {
            if (message == null) throw new ArgumentNullException("message");
            ReactionHandler[] handlers;
            return _handlers.TryGetValue(message.GetType(), out handlers) ? 
                handlers.SelectMany(handler => handler.Handler(message)) : 
                Enumerable.Empty<object>();
        }
    }
}