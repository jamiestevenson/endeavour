using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Response
{
    class ActorResponseModels
    {
    }

    /// <summary>
    /// This class is retuned when the user has requested a directory of actors
    /// </summary>
    public class ActorDirectoryResponseModel
    {
        public ResponseActorDirectoryEntry[] Directory { get; set; }
    }

    public class ResponseActorDirectoryEntry
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }
}
