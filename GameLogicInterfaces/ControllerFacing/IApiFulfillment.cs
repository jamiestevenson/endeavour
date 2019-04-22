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
        /// <summary>
        /// Gets a 'directory' listing of the public information about characters that is public
        /// </summary>
        /// <returns></returns>
        List<Character> AllPublicCharacters();
        /// <summary>
        /// Gets all of the domains for the signed in user
        /// </summary>
        /// <returns></returns>
        List<Domain> AllDomains();
        /// <summary>
        /// Gets information on a specific domain if the signed in user is authorised to see it.
        /// TODO: return random domain if the user cannot view the requested domain
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Domain GetDomainById(string id);

        // Not yet in scope
        //bool DeleteDomain(string id);
        //bool PutCharacter
    }
}
