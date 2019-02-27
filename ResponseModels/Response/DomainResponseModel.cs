using System;
using System.Collections.Generic;

namespace ResponseModels
{
    public class DomainResponseModel
    {
        // TODO may consolidate description fields to a sub-object
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
