using GameLogic;
using GameLogicInterfaces.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace GameLogicTest
{
    public class FulfilmentImplTest
    {
        [Fact]
        public void Constructable()
        {
            FulfilmentImpl actual = new FulfilmentImpl();
            Assert.NotNull(actual);
        }

        [Fact]
        public void GetPlayerCharacterDirectory()
        {
            FulfilmentImpl impl = new FulfilmentImpl();
            List<Character> actual = impl.AllPublicCharacters();
            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }

        [Fact]
        public void ReturnsDomains()
        {
            FulfilmentImpl impl = new FulfilmentImpl();
            List<Domain> actual = impl.AllDomains();
            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }

        // Not sure this is publically available to players for the moment
        //[Fact]
        //public void CanAddDomain()
        //{
        //    FulfilmentImpl impl = new FulfilmentImpl();
        //    Domain domain = new Domain()
        //    {
        //        Id = "TestDomainId",
        //        Description = "A generic domain for testing purposes",
        //        Name = "My Test Domain"
        //    };
        //    impl.AddDomain(domain);

        //}


    }
}
