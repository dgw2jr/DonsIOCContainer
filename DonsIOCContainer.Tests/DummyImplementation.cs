namespace DonsIOCContainer.Tests
{
    public class DummyImplementation : IDummyInterface
    {
        public string SayHello()
        {
            return "Hello!";
        }

        public string State { get; set; }
    }
}