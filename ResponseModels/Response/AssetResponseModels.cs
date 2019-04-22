using System;
using System.Collections.Generic;

namespace ResponseModels.Domain
{
    public class AssetResponseModel
    {
        public ResponseAsset[] Assets { get; set; }
    }

    public class ResponseAsset
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
