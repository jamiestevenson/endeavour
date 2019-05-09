using System;
using System.Collections.Generic;

namespace ApiModels.Response
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
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
