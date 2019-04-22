using GameLogicInterfaces;
using GameLogicInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
    public class FulfilmentImpl : IApiFulfillment
    {
        private readonly List<Domain> _domains = new List<Domain>();
        private readonly List<Character> _characters = new List<Character>();
        private readonly List<Asset> _assets = new List<Asset>();
        private readonly IDictionary<string, List<string>> _characterAssets = new Dictionary<string, List<string>>();

        public FulfilmentImpl ()
        {
            Domain d1 = new Domain()
            {
                Id = "6bcdb901-dab3-4091-a5c9-000000000010",
                Name = "An abandoned lot",
                Description = "This domain is not very interesting"
            };
            Domain d2 = new Domain()
            {         
                Id = "6bcdb901-dab3-4091-a5c9-000000000020",
                Name = "A small park",
                Description = "Well maintained and popular"
            };
            _domains.Add(d1);
            _domains.Add(d2);

            Character c1 = new Character()
            {
                Id = "6bcdb901-dab3-4091-a5c9-000000000030",
                Name = "Mr Character First"
            };
            Character c2 = new Character()
            {
                Id = "6bcdb901-dab3-4091-a5c9-000000000040",
                Name = "Ms Character Second",
                PublicDescription = "Sassy"
            };
            _characters.Add(c1);
            _characters.Add(c2);

            Asset a1 = new Asset()
            {
                Id = "6bcdb901-dab3-4091-a5c9-000000000050",
                Name = "Investments",
                Description = "Well hidden source of income"
            };
            Asset a2 = new Asset()
            {
                Id = "6bcdb901-dab3-4091-a5c9-000000000060",
                Name = "Occult Library",
                Description = "A collection of books and scrolls with a focus on ancient egypt"
            };
            _assets.Add(a1);
            _assets.Add(a2);
            _characterAssets.Add("6bcdb901-dab3-4091-a5c9-000000000030", new List<string>() { "6bcdb901-dab3-4091-a5c9-000000000050" });

        }

        public List<Character> AllPublicActors()
        {
            return _characters;
        }

        public Character GetActorById(string id)
        {
            var match = _characters.Find(d => d.Id.Equals(id));
            return match;
        }

        public List<Domain> AllDomains()
        {
            return _domains;
        }

        public Domain GetDomainById(string id)
        {
            var match = _domains.Find(d => d.Id.Equals(id));
            return match;
        }

        public List<Asset> MyAssets(string playerId)
        {
            List<string> assetIds = _characterAssets[playerId];
            List<Asset> matches = _assets.FindAll(a => assetIds.Contains(a.Id));
            return matches;
        }

        public Asset GetAssetById(string id)
        {
            var match = _assets.Find(d => d.Id.Equals(id));
            return match;
        }

        //public bool DeleteDomain(string id)
        //{
        //    Domain match = _domains.Find(d => d.Id.Equals(id));

        //    if(match != null)
        //    {
        //        return _domains.Remove(match);
        //    }
        //    return false;
        //}
    }
}
