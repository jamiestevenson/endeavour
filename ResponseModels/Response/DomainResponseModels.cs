using System;
using System.Collections.Generic;

namespace ResponseModels.Domain
{
    public class DomainResponseModel
    {
        public ResponseDomain Domain { get; set; }
    }

    public class DomainsResponseModel
    {
        public ResponseDomain[] Domains { get; set; }
    }

    public class ResponseDomain
    {
        // TODO may consolidate description fields to a sub-object
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
