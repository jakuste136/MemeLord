using System;
using FluentAssertions;

namespace Test.Unit.TestUtils
{
    public static class PropertyCountExtension
    {
        public static void ShouldHavePropertyCount(this object type, int count)
        {
            type.GetType().GetProperties().Length.Should().Be(count);
        }
    }
}