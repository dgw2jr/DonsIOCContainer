using System;

namespace DonsIOCContainer
{
    public abstract class RegisteredObject
    {
        protected RegisteredObject(Type typeToResolve, Type concreteType, Lifetime lifetime)
        {
            TypeToResolve = typeToResolve;
            ConcreteType = concreteType;
            Lifetime = lifetime;
        }

        public Type TypeToResolve { get; private set; }

        public Type ConcreteType { get; private set; }

        public object Instance { get; private set; }

        public Lifetime Lifetime { get; private set; }

        public virtual void CreateInstance(params object[] args)
        {
            Instance = Activator.CreateInstance(ConcreteType, args);
        }

        public abstract object GetInstance(params object[] args);
    }
}