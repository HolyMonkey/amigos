using System;
using System.Reflection;

namespace Amigos
{
    public class StateMachineProxy
    {
        private object _target;
        private MethodInfo[] _transitions;
        private object[] _states;

        public StateMachineProxy(object target, MethodInfo[] transitions, object[] states)
        {
            _target = target;
            _transitions = transitions;
            _states = states;
        }
    }
}
