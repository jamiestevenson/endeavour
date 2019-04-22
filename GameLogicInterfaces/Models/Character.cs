using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogicInterfaces.Models
{

    /// <summary>
    /// The root type for characters - this type is shared by players, nps, extras, retainer, etc
    /// Thes properties are the minimum required to count as a 'person' in the system.
    /// </summary>
    public class Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PublicDescription { get; set; }

        public String getDirectoryName()
        {
            return Name;
        }

        public String getDirectoryDescription()
        {
            // TODO generate description from other character traits?
            return PublicDescription == null ? "No description available" : PublicDescription;
        }

    }

}
