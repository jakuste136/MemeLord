using System;
using FluentAssertions;
using MemeLord.DataObjects.Dto;
using MemeLord.Logic.Authentication;
using MemeLord.Logic.Mapping;
using MemeLord.Models;
using NUnit.Framework;
using Test.Unit.TestUtils;

namespace Test.Unit.Logic.Mapping
{
    public class UserMappingTest
    {
        [Test]
        public void Can_Map_From_UserDto_To_User()
        {
            //ARRANGE
            var userDto = new UserDto
            {
                DateOfBirth = new DateTime(1996, 1, 1),
                Username = "Username",
                Password = "Password",
                Email = "email@person.com",
                Sex = Sex.Undefined,
            };

            //ACT
            var sut = new UserDtoMapper();
            var result = sut.Map(userDto);

            //ASSERT
            result.ShouldHavePropertyCount(8);

            var hashStrings = HashManager.StripHashedPassword(result.Hash);
            var hashBytes = Convert.FromBase64String(hashStrings[3]);
            var salt = HashManager.GetSaltFromHashBytes(hashBytes);

            var expectedResult = new User
            {
                DateOfBirth = new DateTime(1996, 1, 1),
                Username = "Username",
                Hash = HashManager.Hash(salt, "Password"),
                Email = "email@person.com",
                Sex = Sex.Undefined,
            };

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
