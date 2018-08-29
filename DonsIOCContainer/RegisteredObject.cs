using System;

namespace DonsIOCContainer
{
    public class RegisteredObject
    {
        public RegisteredObject(Type typeToResolve, Type concreteType, Lifetime lifetime)
        {
            TypeToResolve = typeToResolve;
            ConcreteType = concreteType;
            Lifetime = lifetime;
        }

        public Type TypeToResolve { get; private set; }

        public Type ConcreteType { get; private set; }

        public object Instance { get; private set; }

        public Lifetime Lifetime { get; private set; }

        public void CreateInstance(params object[] args)
        {
            Instance = Activator.CreateInstance(this.ConcreteType, args);
        }
    }
}