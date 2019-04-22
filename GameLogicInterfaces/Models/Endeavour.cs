using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogicInterfaces.Models
{
    /// <summary>
    /// An endeavour:
    /// - is a description of something that is 'in progress'.
    /// - has a defined goal or outcome
    /// - has some notion of progress (current and total required)
    /// - may have assets or actors assigned to it
    /// - may be public or private to an individual or group
    /// </summary>
    public class Endeavour
    {
        public string Id { get; set; }
        public bool IsPublic { get; set; } = false;
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// The result should be a meaningful, tangible change - dots on a sheet, progression of a plot 
        /// </summary>
        public string Result { get; set; }
        public uint EffortRequired { get; set; }
        public uint EffortEarnedSoFar { get; set; }

    }
}
