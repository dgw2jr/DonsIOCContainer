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
