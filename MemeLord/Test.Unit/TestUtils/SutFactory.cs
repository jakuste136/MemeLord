using AutoFixture;

namespace Test.Unit.TestUtils
{
    public static class SutFactory
    {
        public static T CreateSut<T>() where T : class
        {
            return new Fixture().Create<T>();
        }
    }
}