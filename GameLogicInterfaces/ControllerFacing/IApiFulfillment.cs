using GameLogicInterfaces.Models;
using ResponseModels;
using System;
using System.Collections.Generic;

namespace GameLogicInterfaces
{
    /// <summary>
    /// Captures all api-facing functionality
    /// </summary>
    public interface IApiFulfillment
    {
        bool DeleteDomain(string id);
        List<Domain> AllDomains();
        Domain GetDomainById(string id);
    }
}
