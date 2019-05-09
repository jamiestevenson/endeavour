using ApiModels.Response;

namespace ApiModels.Response
{

    public class EndeavourDirectoryResponseModels
    {
    }

    public class EndeavourDirectoryResponseModel {
        public ResponseEndeavourDirectoryEntry[] Directory { get; set; }
    }

    /// <summary>
    /// This class is a reduced summary view of an endeavour for display in a collection.
    /// There may be a more detailed list of endeavours or different notions of progress in future.
    /// </summary>
    public class ResponseEndeavourDirectoryEntry
    {
        public string Id;
        public string Name;
        public uint? ProgressPercent;
    }
}