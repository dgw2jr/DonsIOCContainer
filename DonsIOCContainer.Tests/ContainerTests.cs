using System.Linq;
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
}
