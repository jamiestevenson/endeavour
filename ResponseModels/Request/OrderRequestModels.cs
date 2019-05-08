using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Request
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


    public class OrderRequestModel
    {
        
    }
}
