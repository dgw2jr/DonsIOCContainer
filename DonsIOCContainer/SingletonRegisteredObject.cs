using System;

namespace DonsIOCContainer
{
    public class SingletonRegisteredObject : RegisteredObject
    {
        public SingletonRegisteredObject(Type typeToResolve, Type concreteType) : base(typeToResolve, concreteType, Lifetime.Singleton)
        {
        }
        
        public override object GetInstance(params object[] args)
        {
            if (Instance == null)
            {
                CreateInstance(args);
            }

            return Instance;
        }
    }
}