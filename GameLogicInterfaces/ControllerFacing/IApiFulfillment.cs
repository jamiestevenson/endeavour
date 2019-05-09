using ApiModels.Request;
using ApiModels.Response;
using GameLogicInterfaces.Models;
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
        /// <param name="characterId"></param>
        /// <returns></returns>
        List<Asset> MyAssets(string characterId);
        Asset GetAssetById(string characterId, string assetId);

        /// <summary>
        /// Gets the endeavours that are available to all signed in characters
        /// </summary>
        /// <returns></returns>
        List<Models.Endeavour> GetPublicEndeavours();

        List<Models.Endeavour> GetMyEndeavours(string characterId);

        /// <summary>
        /// Main submission route for orders. Note that orders are not processed immediately on submission
        /// </summary>
        /// <param name="orm"></param>
        /// <returns>A confirmation that the orders have been given a reference</returns>
        SubmitOrdersResponseModel SubmitOrders(SubmitOrdersRequestModel orm);

        
        //TODO - turn on improved nullable checks and use optionals

        // Not yet in scope
        //bool DeleteDomain(string id);
        //bool PutCharacter
    }
}
