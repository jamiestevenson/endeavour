using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Request
{
    class OrderRequestResponseModels
    {
    }

    /// <summary>
    /// This is an updated version of the request, validated to indicate if the orders were accepted by the system.
    /// Note that this is a holding state and is not an indication that the orders have been processed yet.
    /// </summary>
    public class SubmitOrdersResponseModel
    {
        public List<PendingOrderResponseModel> Orders;
    }

    public class PendingOrderResponseModel
    {
        public string Id;
        public string Name;

    }
}
