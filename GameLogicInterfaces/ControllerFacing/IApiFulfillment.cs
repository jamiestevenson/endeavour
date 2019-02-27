using System;

namespace GameLogicInterfaces
{
    /// <summary>
    /// Captures all api-facing functionality
    /// </summary>
    public interface IApiFulfillment
    {
        bool DeleteDomain
            (string id);
    }
}
