using System;
using System.Collections.Generic;

namespace DonsIOCContainer
{
    public class IocContainer
    {
        private readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

        public bool IsRegistered<TType>()
        {
            return _registrations.ContainsKey(typeof(TType));
        }

        public void Register<TInterface, TImpl>() where TImpl : class, TInterface
        {
            if (!IsRegistered<TInterface>())
            {
                _registrations.Add(typeof(TInterface), typeof(TImpl));
            }

            if (!IsRegistered<TImpl>())
            {
                _registrations.Add(typeof(TImpl), typeof(TImpl));
            }
        }

        public TInterface Resolve<TInterface>()
        {
            if (!IsRegistered<TInterface>())
            {
                throw new Exception($"Type {typeof(TInterface).FullName} is not registered.");
            }

            var implementation = _registrations[typeof(TInterface)];

            // TODO: Build instance with constructor parameters
            var instance = Activator.CreateInstance(implementation);

            return (TInterface)instance;
        }
    }
}