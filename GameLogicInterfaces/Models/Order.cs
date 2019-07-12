using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogicInterfaces.Models
{
    /// <summary>
    /// An order:
    /// - is a description of something the player wants to do
    /// - will generate a response
    /// - should change the game (reveal information, change an endeavour, update a character sheet)
    /// </summary>
    public class Order
    {
        public string Id { get; set; }
        public OrderStatus Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Records what was done to action the order for tracability
        /// e.g. <Timestamp>
        ///      Ability increase: Athletics: 2 -> 3
        ///      Experience Spent: 3
        /// </summary>
        public string Result { get; set; }
    }
}
