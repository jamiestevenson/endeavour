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
        List<Character> AllPublicActors();
        /// <summary>
        /// Gets the directory listing for a specific Actor. May give more information.
        /// TODO: Differentiate brief and full public directory listings (maybe)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Character GetActorById(string id);

        /// <summary>
        /// Gets all of the domains for the signed in user (their own domains)
        /// // TODO - public view of some domains that are not yours? e.g. elysia, the rack, publicly known holdings
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

        /// <summary>
        /// Gets all of the assets available to a specific *character*
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        List<Asset> MyAssets(string v);

        // Not yet in scope
        //bool DeleteDomain(string id);
        //bool PutCharacter
    }
}
