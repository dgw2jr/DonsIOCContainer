using Xunit;

namespace DonsIOCContainer.Tests
{
    public class ContainerTests
    {
        [Fact]
        public void Register_ShouldRegisterTypeWithSingletonLifetime()
        {
            var container = new IocContainer();
            container.Register<IDummyInterface, DummyImplementation>(Lifetime.Singleton);

            var instance = container.Resolve<IDummyInterface>();
            instance.State = "State 1";

            var instanceAgain = container.Resolve<IDummyInterface>();

            Assert.Equal("State 1", instanceAgain.State);
        }

        [Fact]
        public void Register_ShouldRegisterTypeWithTransientLifetime()
        {
            var container = new IocContainer();
            container.Register<IDummyInterface, DummyImplementation>(Lifetime.Transient);

            var instance = container.Resolve<IDummyInterface>();
            instance.State = "State 1";

            var instanceAgain = container.Resolve<IDummyInterface>();

            Assert.Null(instanceAgain.State);
        }

        [Fact]
        public void Register_ShouldRegisterTypeAsItself()
        {
            var container = new IocContainer();
            container.Register<IDummyInterface, DummyImplementation>();

            var impl = container.Resolve<DummyImplementation>();

            var hello = impl.SayHello();

            Assert.Equal("Hello!", hello);
        }

        [Fact]
        public void Register_ShouldRegisterTypeAsInterface()
        {
            var container = new IocContainer();
            container.Register<IDummyInterface, DummyImplementation>();

            var impl = container.Resolve<IDummyInterface>();

            var hello = impl.SayHello();

            Assert.Equal("Hello!", hello);
        }

        [Fact]
        public void IsRegistered_ShouldBeTrue_WhenTypeIsRegistered()
        {
            var container = new IocContainer();

            container.Register<IDummyInterface, DummyImplementation>();

            var result = container.IsRegistered<IDummyInterface>();

            Assert.True(result);
        }

        [Fact]
        public void IsRegistered_ShouldBeFalse_WhenTypeIsNotRegistered()
        {
            var container = new IocContainer();
            
            var result = container.IsRegistered<IDummyInterface>();

            Assert.False(result);
        }

        [Fact]
        public void Resolve_ShouldThrowException_WhenTypeIsNotRegistered()
        {
            Assert.Throws<TypeNotRegisteredException>(() => new IocContainer().Resolve<IDummyInterface>());
        }

        [Fact]
        public void Resolve_ShouldReturnConcreteTypeForInterface()
        {
            var container = new IocContainer();
            container.Register<IDummyInterface, DummyImplementation>();

            var impl = container.Resolve<IDummyInterface>();

            Assert.IsType<DummyImplementation>(impl);
        }

        [Fact]
        public void Resolve_ShouldReturnConcreteTypeForSelf()
        {
            var container = new IocContainer();
            container.Register<IDummyInterface, DummyImplementation>();

            var impl = container.Resolve<DummyImplementation>();

            Assert.IsType<DummyImplementation>(impl);
        }
    }
}
