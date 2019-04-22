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
                Description = "This is well maintained and popular"
            };
            _domains.Add(d1);
            _domains.Add(d2);

            Character c1 = new Character() {
                Id = "6bcdb901-dab3-4091-a5c9-000000000030",
                Name = "Mr Character First"
            };
            Character c2 = new Character()
            {
                Id = "6bcdb901-dab3-4091-a5c9-000000000040",
                Name = "Ms Character Second"
            };
            _characters.Add(c1);
            _characters.Add(c2);
        }

        public List<Character> AllPublicCharacters()
        {
            return _characters;
        }

        public List<Domain> AllDomains()
        {
            return _domains;
        }

        public bool DeleteDomain(string id)
        {
            Domain match = _domains.Find(d => d.Id.Equals(id));

            if(match != null)
            {
                return _domains.Remove(match);
            }
            return false;
        }

        public Domain GetDomainById(string id)
        {
            var match = _domains.Find(d => d.Id.Equals(id));
            return match;
        }
    }
}
