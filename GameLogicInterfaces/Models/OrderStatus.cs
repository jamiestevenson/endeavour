namespace GameLogicInterfaces.Models
{
    /// <summary>
    /// This enum covers all possible states for orders in the system.
    /// Currently there are only two:
    /// Pending - the order has bene submitted, but not processed
    /// Processed - the order has been actioned by the ST and is 'done'
    /// </summary>
    public enum OrderStatus
    {
        PENDING,
        PROCESSED
    }
}