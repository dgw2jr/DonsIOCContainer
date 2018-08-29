using System;
using System.Collections.Generic;
using System.Linq;

namespace DonsIOCContainer
{
    public class IocContainer
    {
        private readonly List<RegisteredObject> _registeredObjects = new List<RegisteredObject>();

        public void Register<TTypeToResolve, TConcrete>()
        {
            Register<TTypeToResolve, TConcrete>(Lifetime.Singleton);
        }

        public void Register<TTypeToResolve, TConcrete>(Lifetime lifeCycle)
        {
            if (IsRegistered<TTypeToResolve>())
            {
                return;
            }

            _registeredObjects.Add(new RegisteredObject(typeof(TTypeToResolve), typeof(TConcrete), lifeCycle));
            _registeredObjects.Add(new RegisteredObject(typeof(TConcrete), typeof(TConcrete), lifeCycle));
        }

        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            return (TTypeToResolve)ResolveObject(typeof(TTypeToResolve));
        }

        public object Resolve(Type typeToResolve)
        {
            return ResolveObject(typeToResolve);
        }

        private object ResolveObject(Type typeToResolve)
        {
            var registeredObject = _registeredObjects.FirstOrDefault(o => o.TypeToResolve == typeToResolve);
            if (registeredObject == null)
            {
                throw new TypeNotRegisteredException($"The type {typeToResolve.Name} has not been registered.");
            }

            return GetInstance(registeredObject);
        }

        private object GetInstance(RegisteredObject registeredObject)
        {
            if (registeredObject.Instance != null && registeredObject.Lifetime != Lifetime.Transient)
            {
                return registeredObject.Instance;
            }

            var parameters = ResolveConstructorParams(registeredObject);
            registeredObject.CreateInstance(parameters.ToArray());
            return registeredObject.Instance;
        }

        private IEnumerable<object> ResolveConstructorParams(RegisteredObject registeredObject)
        {
            // Try to get the greediest constructor
            var constructorInfo = registeredObject.ConcreteType.GetConstructors().OrderByDescending(c => c.GetParameters().Length).First();

            foreach (var parameter in constructorInfo.GetParameters())
            {
                yield return ResolveObject(parameter.ParameterType);
            }
        }

        public bool IsRegistered<T>()
        {
            return _registeredObjects.Any(r => r.TypeToResolve == typeof(T));
        }
    }
}