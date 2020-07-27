using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using ApiModels.Response;
using GameLogicInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endeavour.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AssetsController : Controller
    {
        // TODO add injected backing service implementation
        private readonly IApiFulfillment _backingService;

        public AssetsController(IApiFulfillment backingService)
        {
            _backingService = backingService;
        }

        // GET api/asset
        [HttpGet]
        public AssetResponseModel Get()
        {
            //FIXME 
            //TODO get logged in character ID from header
            string mrCharFirstId = "6bcdb901-dab3-4091-a5c9-000000000030";
            String loggedInCharacterIdFromHeader = mrCharFirstId;
            var assets = _backingService.MyAssets(loggedInCharacterIdFromHeader);

            return new AssetResponseModel()
            {
                Assets = assets.Select(a => ResponseMapper.ToResponseAsset(a)).ToArray<ResponseAsset>()
            };
        }

        // GET api/asset/5
        [HttpGet("{id}")]
        public AssetResponseModel Get(string id)
        {
            //FIXME 
            //TODO get logged in character ID from header
            string mrCharFirstId = "6bcdb901-dab3-4091-a5c9-000000000030";
            String loggedInCharacterIdFromHeader = mrCharFirstId;

            if (String.IsNullOrEmpty(id.Trim()))
            {
                return null;
            }

            var asset = _backingService.GetAssetById(loggedInCharacterIdFromHeader, id);

            if (asset == null)
            {
                return null;
            }

            // Get a resource
            return new AssetResponseModel()
            {
                Assets = new ResponseAsset[] { ResponseMapper.ToResponseAsset(asset) }
            };
        }

        // DELETE api/domain
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            //FIXME
            //TODO get logged in character id from header
            
        }
    }
}
