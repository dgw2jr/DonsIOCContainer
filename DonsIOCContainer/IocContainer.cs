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

        public void Register<TTypeToResolve, TConcrete>(Lifetime lifetime)
        {
            if (IsRegistered<TTypeToResolve>())
            {
                return;
            }

            var registeredObjectForInterface = RegisteredObjectFactory.Create<TTypeToResolve, TConcrete>(lifetime);
            var registeredObjectForConcrete = RegisteredObjectFactory.Create<TConcrete, TConcrete>(lifetime);
            _registeredObjects.Add(registeredObjectForInterface);
            _registeredObjects.Add(registeredObjectForConcrete);

            //switch (lifetime)
            //{
            //    case Lifetime.Transient:
            //        _registeredObjects.Add(new TransientRegisteredObject(typeof(TTypeToResolve), typeof(TConcrete)));
            //        _registeredObjects.Add(new TransientRegisteredObject(typeof(TConcrete), typeof(TConcrete)));
            //        break;
            //    case Lifetime.Singleton:
            //        _registeredObjects.Add(new SingletonRegisteredObject(typeof(TTypeToResolve), typeof(TConcrete)));
            //        _registeredObjects.Add(new SingletonRegisteredObject(typeof(TConcrete), typeof(TConcrete)));
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException(nameof(lifetime), lifetime, null);
            //}
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
            var parameters = ResolveConstructorParams(registeredObject);
            return registeredObject.GetInstance(parameters.ToArray());
        }

        private IEnumerable<object> ResolveConstructorParams(RegisteredObject registeredObject)
        {
            // Try to get the greediest constructor
            var constructorInfo = registeredObject.ConcreteType.GetConstructors().OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
            if (constructorInfo == null)
            {
                yield return new List<object>();
            }

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