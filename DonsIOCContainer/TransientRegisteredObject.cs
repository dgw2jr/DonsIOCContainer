using System;

namespace DonsIOCContainer
{
    public class TransientRegisteredObject : RegisteredObject
    {
        public TransientRegisteredObject(Type typeToResolve, Type concreteType) : base(typeToResolve, concreteType, Lifetime.Transient)
        {
        }

        public override object GetInstance(params object[] args)
        {
            CreateInstance(args);
            return Instance;
        }
    }
}