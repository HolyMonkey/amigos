using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Amigos
{
    class StateMachineProxyBuilder
    {
        public StateMachineProxy Bake(object target)
        {
            Type targetType = target.GetType();

            if (targetType.GetCustomAttribute<StateMachine>() == null)
                throw new ArgumentException(nameof(target));


            MethodInfo[] transitions = GetTransitions(targetType);
            Type[] statesTypes = GetStates(targetType);
            object[] statesObjects = CreateStatesInstances(statesTypes);

            return new StateMachineProxy(target, transitions, statesObjects);
        }

        private MethodInfo[] GetTransitions(Type targetType)
        {
            return targetType.GetMethods()
                .Where(method => method.GetCustomAttribute<TransitionAttribute>() != null)
                .ToArray();
        }

        private Type[] GetStates(Type targetType)
        {
            return targetType.GetNestedTypes()
                .Where(type => type.GetCustomAttribute<StateAttribute>() != null)
                .ToArray();
        }
        private object[] CreateStatesInstances(Type[] statesTypes)
        {
            List<object> instances = new List<object>(statesTypes.Length);

            foreach (var stateType in statesTypes)
            {
                //there is need DI
                var instance = Activator.CreateInstance(stateType);
                instances.Add(instance);
            }

            return instances;
        }
    }
}
