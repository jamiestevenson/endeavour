using GameLogicInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogicInterfaces.Datasource
{
    public class GameDataStub : IGameData
    {

        private readonly List<Domain> _domains = new List<Domain>();
        private readonly List<Character> _characters = new List<Character>();
        private readonly List<Asset> _assets = new List<Asset>();
        /// <summary>
        /// The ids of assets belonging to a given character
        /// </summary>
        private readonly IDictionary<string, List<string>> _characterAssets = new Dictionary<string, List<string>>();
        private readonly List<GameLogicInterfaces.Models.Endeavour> _endeavours = new List<GameLogicInterfaces.Models.Endeavour>();
        /// <summary>
        /// The ids of endeavours visible to a given character
        /// </summary>
        private readonly IDictionary<string, List<string>> _characterEndeavours = new Dictionary<string, List<string>>();

        public GameDataStub()
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
            _characterAssets.Add(c1.Id, new List<string>() { a1.Id });

            GameLogicInterfaces.Models.Endeavour e1 = new GameLogicInterfaces.Models.Endeavour()
            {
                Id = "6bcdb901-dab3-4091-a5c9-000000000070",
                Name = "Test Public Endeavour",
                IsPublic = true,
                Result = "The recent sabbat incursion is covered up",
                Description = "Exists to test public endeavours such as calls to arms, cover ups, or public works projects.",
                EffortRequired = 100
            };
            GameLogicInterfaces.Models.Endeavour e2 = new GameLogicInterfaces.Models.Endeavour()
            {
                Id = "6bcdb901-dab3-4091-a5c9-000000000080",
                Name = "Test Private Endeavour",
                Result = "Camarilla influence is increased",
                Description = "Exists to test private endeavours such as building haven or influence, research, or gaining status",
                EffortEarnedSoFar = 3,
                EffortRequired = 15
            };
            _endeavours.Add(e1);
            _endeavours.Add(e2);
            _characterEndeavours.Add(c1.Id, new List<string> { e2.Id });

        }

        public List<Asset> Assets()
        {
            return _assets;
        }

        public List<string> AssetsForCharacter(string characterId)
        {
            return _characterAssets[characterId];
        }

        public List<string> EndeavoursForCharacter(string characterId)
        {
            List<string> reply = new List<string>();

            if (_characterEndeavours.ContainsKey(characterId))
            {
                _characterEndeavours.TryGetValue(characterId, out reply);
            }

            return reply;
        }

        public List<Endeavour> Endeavours()
        {
            return _endeavours;
        }

        public List<Character> GetActors()
        {
            return _characters;
        }

        public List<Domain> GetDomains()
        {
            return _domains;
        }
    }
}
