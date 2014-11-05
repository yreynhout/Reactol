using System.Collections.Generic;

namespace Reactol
{
    /// <summary>
    /// 
    /// </summary>
    public class ReactionComposer
    {
        public ReactionComposer Compose(object message) { }
        public ReactionComposer Compose(object[] message) { }
        public ReactionComposer Compose(IEnumerable<object> message) { }

        public ReactionComposer ComposeIf(bool condition, object message) { }
        public ReactionComposer ComposeIf(bool condition, object[] message) { }
        public ReactionComposer ComposeIf(bool condition, IEnumerable<object> message) { }

        public ReactionComposer ComposeUnless(bool condition, object message) { }
        public ReactionComposer ComposeUnless(bool condition, object[] message) { }
        public ReactionComposer ComposeUnless(bool condition, IEnumerable<object> message) { }
    }
}