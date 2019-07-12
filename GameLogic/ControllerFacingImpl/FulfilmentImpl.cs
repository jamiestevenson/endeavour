using ApiModels.Request;
using ApiModels.Response;
using GameLogicInterfaces;
using GameLogicInterfaces.Datasource;
using GameLogicInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
    public class FulfilmentImpl : IApiFulfillment
    {
        private IGameData _data;


        public FulfilmentImpl(IGameData gameData)
        {
            this._data = gameData;
        }

        public List<Character> AllPublicActors()
        {
            // Will have to filter out non-public actors
            return _data.GetActors();
        }

        public Character GetActorById(string id)
        {
            var match = _data.GetActors().Find(d => d.Id.Equals(id));
            return match;
        }

        public List<Domain> AllDomains()
        {
            return _data.GetDomains();
        }

        public Domain GetDomainById(string id)
        {
            var match = _data.GetDomains().Find(d => d.Id.Equals(id));
            return match;
        }

        public List<Asset> MyAssets(string characterId)
        {
            List<string> assetIds = _data.AssetsForCharacter(characterId);
            List<Asset> matches = _data.Assets().FindAll(a => assetIds.Contains(a.Id));
            return matches;
        }

        public Asset GetAssetById(string characterId, string assetId)
        {
            List<string> assetIds = _data.AssetsForCharacter(characterId);
            if (assetIds.Contains(assetId))
            {
                List<Asset> matches = _data.Assets().FindAll(a => assetIds.Contains(a.Id));
                var match = _data.Assets().Find(d => d.Id.Equals(assetId));
                return match;
            }
            return null;
        }

        public List<GameLogicInterfaces.Models.Endeavour> GetPublicEndeavours()
        {
            return _data.Endeavours().FindAll(e => e.IsPublic);
        }

        public List<GameLogicInterfaces.Models.Endeavour> GetMyEndeavours(string characterId)
        {
            List<string> endeavourIds = _data.EndeavoursForCharacter(characterId);
            return _data.Endeavours().FindAll(e => endeavourIds.Contains(e.Id));
        }

        public List<Order> SubmitOrders(SubmitOrdersRequestModel orm, String characterId)
        {
            var response = new List<Order>();

            //TODO send orders to orders repo

            foreach (OrderRequestModel submission in orm.Orders)
            {
                response.Add(MapToPending(submission));
            }

            return response;
        }

        private Order MapToPending(OrderRequestModel orm)
        {
            return new Order
            {
                Id = Guid.NewGuid().ToString(),
                Name = orm.Name,
                Status = OrderStatus.PENDING
            };
        }

        public List<Order> GetLastOrders()
        {
            // TODO implement
            throw new NotImplementedException();
        }
    }
}
