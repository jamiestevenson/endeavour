using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogicInterfaces.Models
{
    /// <summary>
    /// A Domain is a place - this can be anything from a phone box up to a region of a 
    /// country. The purpose of a Domain is to be in control of it.
    /// 
    /// Domains can hold various kinds of asset
    /// 
    /// Example - A stately home, where the Domain is the grounds.
    /// Assets: Mansion, Haven, Retainers, Library
    /// </summary>
    public class Domain
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
