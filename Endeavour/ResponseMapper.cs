using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiModels.Response;
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

        internal static ResponseActorDirectoryEntry ToResponseActorDirectoryEntry(Character c)
        {
            return new ResponseActorDirectoryEntry()
            {
                Id = c.Id,
                Name = c.getDirectoryName(),
                Description = c.getDirectoryDescription()
            };

        }
    }
}
