using GameLogic;
using GameLogicInterfaces;
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
            IApiFulfillment actual = new FulfilmentImpl();
            Assert.NotNull(actual);
        }

        [Fact]
        public void GetPlayerCharacterDirectory()
        {
            IApiFulfillment impl = new FulfilmentImpl();
            List<Character> actual = impl.AllPublicActors();
            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }

        [Fact]
        public void CharactersInDirectoryArePopulated()
        {
            IApiFulfillment impl = new FulfilmentImpl();
            List<Character> actual = impl.AllPublicActors();
            Character mrActual = actual[0];
            Assert.NotNull(mrActual.Id);
            Assert.NotNull(mrActual.getDirectoryName());
            Assert.NotNull(mrActual.getDirectoryDescription());
        }

        [Fact]
        public void ReturnsDomains()
        {
            IApiFulfillment impl = new FulfilmentImpl();
            List<Domain> actual = impl.AllDomains();
            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }

        [Fact]
        public void DomainsArePopulated()
        {
            IApiFulfillment impl = new FulfilmentImpl();
            List<Domain> actual = impl.AllDomains();
            Domain aDomain = actual[0];
            Assert.NotNull(aDomain.Id);
            Assert.NotNull(aDomain.Name);
            Assert.NotNull(aDomain.Description);
        }

        [Fact]
        public void ReturnsAssets()
        {
            // TODO - id always required? any unattached assets 
            string mrCharFirstId = "6bcdb901-dab3-4091-a5c9-000000000030";
            IApiFulfillment impl = new FulfilmentImpl();
            List<Asset> actual = impl.MyAssets(mrCharFirstId);
            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }

        [Fact]
        public void MyAssetsArePopulated()
        {
            string mrCharFirstId = "6bcdb901-dab3-4091-a5c9-000000000030";
            IApiFulfillment impl = new FulfilmentImpl();
            List<Asset> actual = impl.MyAssets(mrCharFirstId);
            Asset anAsset = actual[0];
            Assert.NotNull(anAsset.Id);
            Assert.NotNull(anAsset.Name);
            Assert.NotNull(anAsset.Description);
        }

        [Fact]
        public void ReturnsJustMyAssets()
        {
            string mrCharFirstId = "6bcdb901-dab3-4091-a5c9-000000000030";
            IApiFulfillment impl = new FulfilmentImpl();
            List<Asset> actual = impl.MyAssets(mrCharFirstId);
            Assert.Single(actual);
            Asset asset = actual[0];
            Assert.Equal("6bcdb901-dab3-4091-a5c9-000000000050", asset.Id);
            Assert.Equal("Investments", asset.Name);
            Assert.Equal("Well hidden source of income", asset.Description);
        }
    }
}
