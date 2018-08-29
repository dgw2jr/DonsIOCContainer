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
    }
}
