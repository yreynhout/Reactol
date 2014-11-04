using System;

namespace Reactol
{
    /// <summary>
    ///     Represent a message reaction.
    /// </summary>
    public class Reaction
    {
        /// <summary>
        /// Returns a <see cref="Reaction"/> instance without handlers.
        /// </summary>
        public static readonly Reaction Empty = new Reaction(new ReactionHandler[0]);

        private readonly ReactionHandler[] _handlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="Reaction"/> class.
        /// </summary>
        /// <param name="handlers">The handlers.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="handlers"/> are <c>null</c>.</exception>
        public Reaction(ReactionHandler[] handlers)
        {
            if (handlers == null) throw new ArgumentNullException("handlers");
            _handlers = handlers;
        }

        /// <summary>
        ///     Gets a read only collection of reaction handlers.
        /// </summary>
        /// <value>
        ///     The reaction handlers associated with this reaction.
        /// </value>
        public ReactionHandler[] Handlers
        {
            get { return _handlers; }
        }

        /// <summary>
        ///     Concatenates the handlers of this reaction with the handlers of the specified reaction.
        /// </summary>
        /// <param name="reaction">The reaction to concatenate.</param>
        /// <returns>A <see cref="Reaction"/> containing the concatenated handlers.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="reaction"/> is <c>null</c>.</exception>
        public Reaction Concat(Reaction reaction)
        {
            if (reaction == null) throw new ArgumentNullException("reaction");
            var concatenated = new ReactionHandler[_handlers.Length + reaction._handlers.Length];
            _handlers.CopyTo(concatenated, 0);
            reaction._handlers.CopyTo(concatenated, _handlers.Length);
            return new Reaction(concatenated);
        }

        /// <summary>
        ///     Concatenates the handlers of this reaction with the specified reaction handler.
        /// </summary>
        /// <param name="handler">The reaction handler to concatenate.</param>
        /// <returns>A <see cref="Reaction"/> containing the concatenated handlers.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="handler"/> is <c>null</c>.</exception>
        public Reaction Concat(ReactionHandler handler)
        {
            if (handler == null) throw new ArgumentNullException("handler");
            var concatenated = new ReactionHandler[_handlers.Length + 1];
            _handlers.CopyTo(concatenated, 0);
            concatenated[_handlers.Length] = handler;
            return new Reaction(concatenated);
        }

        /// <summary>
        ///     Concatenates the handlers of this reaction with the specified reaction handlers.
        /// </summary>
        /// <param name="handlers">The reaction handlers to concatenate.</param>
        /// <returns>A <see cref="Reaction"/> containing the concatenated handlers.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="handlers"/> are <c>null</c>.</exception>
        public Reaction Concat(ReactionHandler[] handlers)
        {
            if (handlers == null) throw new ArgumentNullException("handlers");
            var concatenated = new ReactionHandler[_handlers.Length + handlers.Length];
            _handlers.CopyTo(concatenated, 0);
            handlers.CopyTo(concatenated, _handlers.Length);
            return new Reaction(concatenated);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Reaction"/> to <see><cref>ReactionHandler[]</cref></see>.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="instance"/> is <c>null</c>.</exception>
        public static implicit operator ReactionHandler[](Reaction instance)
        {
            if (instance == null) throw new ArgumentNullException("reaction");
            return instance.Handlers;
        }
    }
}