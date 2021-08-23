using System;

namespace Amigos
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TransitionAttribute : Attribute 
    {
        public readonly Type To;

        public TransitionAttribute(Type to) => To = to;

        public TransitionAttribute() => To = null;
    }
}
