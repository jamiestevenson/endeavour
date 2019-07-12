using ApiModels.Request;
using ApiModels.Response;
using GameLogic;
using GameLogicInterfaces;
using GameLogicInterfaces.Datasource;
using GameLogicInterfaces.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace GameLogicTest
{
    public class FulfilmentImplTest
    {
        private static string MR_CHARACTER_FIRST_ID = "6bcdb901-dab3-4091-a5c9-000000000030";
        private static string MS_CHARACTER_SECOND_ID = "6bcdb901-dab3-4091-a5c9-000000000040";

        [Fact]
        public void Constructable()
        {
            IApiFulfillment actual = new FulfilmentImpl(null);
            Assert.NotNull(actual);
        }

        [Fact]
        public void GetPlayerCharacterDirectory()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<Character> actual = impl.AllPublicActors();
            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }

        [Fact]
        public void CharactersInDirectoryArePopulated()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<Character> actual = impl.AllPublicActors();
            Character mrActual = actual[0];
            Assert.NotNull(mrActual.Id);
            Assert.NotNull(mrActual.getDirectoryName());
            Assert.NotNull(mrActual.getDirectoryDescription());
        }

        [Fact]
        public void ReturnsDomains()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<Domain> actual = impl.AllDomains();
            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }

        [Fact]
        public void DomainsArePopulated()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
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
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<Asset> actual = impl.MyAssets(MR_CHARACTER_FIRST_ID);
            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }

        [Fact]
        public void MyAssetsArePopulated()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<Asset> actual = impl.MyAssets(MR_CHARACTER_FIRST_ID);
            Asset anAsset = actual[0];
            Assert.NotNull(anAsset.Id);
            Assert.NotNull(anAsset.Name);
            Assert.NotNull(anAsset.Description);
        }

        [Fact]
        public void ReturnsJustMyAssets()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<Asset> actual = impl.MyAssets(MR_CHARACTER_FIRST_ID);
            Assert.Single(actual);
            Asset asset = actual[0];
            Assert.Equal("6bcdb901-dab3-4091-a5c9-000000000050", asset.Id);
            Assert.Equal("Investments", asset.Name);
            Assert.Equal("Well hidden source of income", asset.Description);
        }

        [Fact]
        public void ReturnsEndeavours()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<GameLogicInterfaces.Models.Endeavour> actual = impl.GetPublicEndeavours();
            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }

        [Fact]
        public void EndeavoursArePopulated()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<GameLogicInterfaces.Models.Endeavour> actual = impl.GetPublicEndeavours();
            GameLogicInterfaces.Models.Endeavour e = actual[0];
            Assert.NotNull(e.Id);
            Assert.NotNull(e.Name);
            Assert.NotNull(e.Result);
            Assert.NotNull(e.Description);
            Assert.True(e.EffortEarnedSoFar <= e.EffortRequired);
        }

        [Fact]
        public void ReturnsOnlyPublicEndeavours()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<GameLogicInterfaces.Models.Endeavour> actual = impl.GetPublicEndeavours();
            Assert.Single(actual);
            GameLogicInterfaces.Models.Endeavour e = actual[0];
            Assert.Equal("6bcdb901-dab3-4091-a5c9-000000000070", e.Id);
            Assert.Equal("Test Public Endeavour", e.Name);
            Assert.Equal("The recent sabbat incursion is covered up", e.Result);
            Assert.Equal("Exists to test public endeavours such as calls to arms, cover ups, or public works projects.", e.Description);
            Assert.Equal<uint>(0, e.EffortEarnedSoFar);
            Assert.Equal<uint>(100, e.EffortRequired);
        }

        [Fact]
        public void ReturnsNoPrivateEndeavoursIfIHaveNone()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<GameLogicInterfaces.Models.Endeavour> actual = impl.GetMyEndeavours(MS_CHARACTER_SECOND_ID);
            Assert.Empty(actual);
        }

        [Fact]
        public void ReturnsOnlyMyPrivateEndeavours()
        { 
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<GameLogicInterfaces.Models.Endeavour> actual = impl.GetMyEndeavours(MR_CHARACTER_FIRST_ID);
            Assert.Single(actual);
            GameLogicInterfaces.Models.Endeavour e = actual[0];
            Assert.Equal("6bcdb901-dab3-4091-a5c9-000000000080", e.Id);
            Assert.Equal("Test Private Endeavour", e.Name);
            Assert.False(e.IsPublic);
            Assert.Equal("Camarilla influence is increased", e.Result);
            Assert.Equal("Exists to test private endeavours such as building haven or influence, research, or gaining status", e.Description);
            Assert.Equal<uint>(3, e.EffortEarnedSoFar);
            Assert.Equal<uint>(15, e.EffortRequired);
        }

        [Fact]
        public void SubmitEmptyOrder()
        {
            string msCharacterSecondId = "6bcdb901-dab3-4091-a5c9-000000000040";
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            SubmitOrdersRequestModel orm = new SubmitOrdersRequestModel
            {
                Orders = new List<OrderRequestModel>()
            };
            List<Order> actual = impl.SubmitOrders(orm, msCharacterSecondId);
            Assert.Empty(actual);
        }

        [Fact]
        public void SubmitAnOrder_CreateEndeavour()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            SubmitOrdersRequestModel orm = new SubmitOrdersRequestModel()
            {
                Orders = new List<OrderRequestModel>()
                {
                    new CreateEndeavorOrderRequestModel()
                    {
                        Name = "Investigate Arcane Grafitti",
                        Goal = "Create endeavour to find out more about the obviously arcane writing that has been appearing around Glasgow.",
                        Method = "Task photgraphy students as assignment to capture grafitti, pass the images to my contact at the art museum",
                        Assets = new List<string>(),
                        Actors = new List<string>()
                    }
                }
            };
            List<Order> actual = impl.SubmitOrders(orm, MR_CHARACTER_FIRST_ID);
            Assert.NotNull(actual);
            Assert.Single(actual);
            Assert.NotNull(actual[0].Id);
            Assert.Equal("Investigate Arcane Grafitti", actual[0].Name);
        }

        [Fact]
        public void SubmitAnOrder_SupportPublicEndeavour()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<GameLogicInterfaces.Models.Endeavour> publicEffort = impl.GetPublicEndeavours();

            SubmitOrdersRequestModel orm = new SubmitOrdersRequestModel()
            {
                Orders = new List<OrderRequestModel>()
                {
                    new SupportEndeavorOrderRequestModel ()
                    {
                        IdToSupport = publicEffort[0].Id,
                        Name = "Help with the Sabbat cover-up",
                        MethodOfSupport = "Be there in person to help with mental disciplines",
                        Assets = new List<string>(),
                        Actors = new List<string>()
                    }
                }
            };
            List<Order> actual = impl.SubmitOrders(orm, MS_CHARACTER_SECOND_ID);
            Assert.NotNull(actual);
            Assert.Single(actual);
            Assert.NotNull(actual[0].Id);
            Assert.Equal("Help with the Sabbat cover-up", actual[0].Name);
        }

        [Fact]
        public void SubmitAnOrder_OppposePublicEndeavour()
        {
            IApiFulfillment impl = new FulfilmentImpl(new GameDataStub());
            List<GameLogicInterfaces.Models.Endeavour> publicEffort = impl.GetPublicEndeavours();

            SubmitOrdersRequestModel orm = new SubmitOrdersRequestModel()
            {
                Orders = new List<OrderRequestModel>()
                {
                    new OpposeEndeavorOrderRequestModel ()
                    {
                        IdToOppose = publicEffort[0].Id,
                        Name = "Hinder the Sabbat cover-up",
                        MethodOfOpposition = "Pass the information I have to the media",
                        Assets = new List<string>(),
                        Actors = new List<string>()
                    }
                }
            };
            List<Order> actual = impl.SubmitOrders(orm, MR_CHARACTER_FIRST_ID);
            Assert.NotNull(actual);
            Assert.Single(actual);
            Assert.NotNull(actual[0].Id);
            Assert.Equal("Hinder the Sabbat cover-up", actual[0].Name);
        }

        [Fact]
        public void Todo()
        {
            Assert.True(false);

            // Fix dependency injeciton for gamadata source - this fails on run and unit tests at the moment
            // Pull mock data out of fulfulment impl to mock data source
            // Add basic front end to let it drive interactions
            // Add login and sign up
            // Add model validation for input
            // Add better error response code and complimentary handler component on front end
            // Add more mock data
            // Canvas users for downtime action types
            // Build GM screen
            // Turn on enhanced nullables and fix warnings (on hold until C# 8.0 release).
        }
    }
}
