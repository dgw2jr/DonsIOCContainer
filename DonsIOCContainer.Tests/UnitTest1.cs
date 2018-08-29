using System;
using System.Collections.Generic;
using Xunit;

namespace DonsIOCContainer.Tests
{
    public class ContainerTests
    {
        [Fact]
        public void Register_ShouldRegisterTypeAsItself()
        {
            var container = new IocContainer();
            container.Register<IDummyInterface, DummyImplementation>();

            var impl = container.Resolve<DummyImplementation>();
        }

        [Fact]
        public void IsRegistered_ShouldBeTrue_WhenTypeIsRegistered()
        {

        }
    }

    public class DummyImplementation : IDummyInterface
    {
        public string SayHello()
        {
            return "Hello!";
        }
    }

    public interface IDummyInterface
    {
        string SayHello();
    }

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

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }
    }
}
