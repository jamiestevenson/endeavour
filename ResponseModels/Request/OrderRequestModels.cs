using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Response
{
    /// <summary>
    /// Orders are the main way players give input to the system.
    /// Orders are processed periodically e.g. monthly
    /// Players have a number of order slots per period e.g. six
    /// Once submitted, all orders are processed after the closing date
    /// Players can update orders until this closing date
    /// Orders fall into broad categories:
    /// - Initiate Endeavour (player owns)
    /// - Support known endeavour
    /// - Oppose known endeavour
    /// </summary>
    class OrderRequestModels
    {
    }

    public class SubmitOrdersRequestModel
    {
        public List<OrderRequestModel> Orders { get; set; }
    }

    public class OrderRequestModel
    {
        public string Name { get; set; }
    }

    public class CreateEndeavorOrderRequestModel : OrderRequestModel
    {
        public string Goal { get; set; }
        public string Method { get; set; }
        public List<string> Assets { get; set; }
        public List<string> Actors { get; set; }
    }

    public class SupportEndeavorOrderRequestModel : OrderRequestModel
    {
        public string IdToSupport { get; set; }
        public string MethodOfSupport { get; set; }
        public List<string> Assets { get; set; }
        public List<string> Actors { get; set; }
    }

    public class OpposeEndeavorOrderRequestModel : OrderRequestModel
    {
        public string IdToOppose { get; set; }
        public string MethodOfOpposition { get; set; }
        public List<string> Assets { get; set; }
        public List<string> Actors { get; set; }
    }
}
