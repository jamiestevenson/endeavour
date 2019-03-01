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

        public FulfilmentImpl ()
        {
            Domain d1 = new Domain()
            {
                Id = "6bcdb901-dab3-4091-a5c9-5d9dda70bcdd",
                Name = "An abandoned lot",
                Description = "This domain is not very interesting"
            };
            Domain d2 = new Domain()
            {
                Id = "6b793e38-ddf4-4cf8-9a51-971289712810",
                Name = "A small park",
                Description = "This is well maintained and popular"
            };
            _domains.Add(d1);
            _domains.Add(d2);
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
