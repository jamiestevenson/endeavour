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
        public PendingOrderModel[] Orders;
    }

    public class OrdersResponseModel
    {
        public OrderResponseModel[] Orders;
    }

    public class OrderResponseModel
    {
        public string Id;
        public string State;
        public string Name;
        public string Description;
        public string Consequence;
    }

    /// <summary>
    /// This model is for when there is a direct request for the pending orders for a player.
    /// </summary>
    public class PendingOrdersResponseModel
    {
        public PendingOrderModel[] Orders;
    }

    public class PendingOrderModel
    {
        public string Id;
        public string Name;
    }
}
