using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLogicInterfaces.Models;
using ResponseModels;
using ResponseModels.Domain;

namespace API
{
    /// <summary>
    /// Maps first line models from API fulfilment to response models
    /// </summary>
    public class ResponseMapper
    {
        internal static ResponseDomain ToResponseDomain(Domain d)
        {
            return new ResponseDomain()
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            };
        }
    }
}
