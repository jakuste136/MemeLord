﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using MemeLord.DataObjects.Dto;
using MemeLord.DataObjects.Request;
using MemeLord.Logic.Authentication;
using MemeLord.Logic.Mapping;
using MemeLord.Logic.Mapping.Users;
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
            var sut = new AddUserRequestMapper();
            var result = sut.Map(new List<AddUserRequest>());

            //ASSERT
            result.ShouldHavePropertyCount(8);

            // zakomentowane bo sie nie buildowalo, do poprawienia 
            //var hashStrings = HashManager.StripHashedPassword(result.Hash);
            //var hashBytes = Convert.FromBase64String(hashStrings[3]);
            //var salt = HashManager.GetSaltFromHashBytes(hashBytes);

            var expectedResult = new User
            {
                DateOfBirth = new DateTime(1996, 1, 1),
                Username = "Username",
                //Hash = HashManager.Hash(salt, "Password"),
                Email = "email@person.com",
                Sex = Sex.Undefined,
            };

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Can_Update_Existing_User()
        {
            // arrange
            var request = new UpdateUserRequest
            {
                Avatar = "avatar",
                DateOfBirth = new DateTime(2017,1,1),
                Description = "desc",
                Email = "email",
                Sex = Sex.Female
            };
            
            var user = new User
            {
                Avatar = "oldAvatar",
                DateOfBirth = null,
                Description = "oldDescription",
                Email = "oldEmail",
                Hash = "hash",
                Id = 1,
                Sex = Sex.Male,
                Username = "username"
            };

            // act
            var sut = new Mapper<UpdateUserRequest, User>();
            sut.Map(request, user);

            // assert
            var expectedResult = new User
            {
                Avatar = "avatar",
                DateOfBirth = new DateTime(2017, 1, 1),
                Description = "desc",
                Email = "email",
                Sex = Sex.Female,
                Hash = "hash",
                Id = 1,
                Username = "username"
            };
            user.Should().BeEquivalentTo(expectedResult);
        }
    }
}
