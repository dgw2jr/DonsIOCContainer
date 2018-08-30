using System;
using System.Collections.Generic;

namespace DonsIOCContainer
{
    public static class RegisteredObjectFactory
    {
        private static readonly Dictionary<Lifetime, Func<Type, Type, RegisteredObject>> RegisteredObjectFactories = new Dictionary<Lifetime, Func<Type, Type, RegisteredObject>>
        {
            { Lifetime.Singleton, (typeToResolve, typeToRegister) => new SingletonRegisteredObject(typeToResolve, typeToRegister) },
            { Lifetime.Transient, (typeToResolve, typeToRegister) => new TransientRegisteredObject(typeToResolve, typeToRegister) }
            // Additional factories can be added here
        }; 

        public static RegisteredObject Create<TToResolve, TToRegister>(Lifetime lifetime)
        {
            return RegisteredObjectFactories[lifetime](typeof(TToResolve), typeof(TToRegister));
        }
    }
}