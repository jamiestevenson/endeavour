using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiModels.Response;
using GameLogicInterfaces.Models;

namespace API
{
    /// <summary>
    /// Maps first line models from API fulfilment to response models.
    /// These are currently very similar, but the response models will be processed
    /// here to exclude unnecessary data, summarise, and remove some info as
    /// development goes on.
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

        internal static ResponseEndeavourDirectoryEntry ToResponseEndeavourDirectoryEntry(GameLogicInterfaces.Models.Endeavour c)
        {
            return new ResponseEndeavourDirectoryEntry()
            {
                Id = c.Id,
                Name = c.Name,
                ProgressPercent = calculatePercentageProgress(c.EffortEarnedSoFar, c.EffortRequired)
            };
        }

        private static uint? calculatePercentageProgress(uint? soFar, uint? goal)
        {
            if (soFar.HasValue && soFar.HasValue)
            {
                return (uint)soFar / goal;
            }
            return null;
        }

        internal static ResponseAsset ToResponseAsset(Asset d)
        {
            return new ResponseAsset()
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            };
        }
    }
}
