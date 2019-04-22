namespace GameLogicInterfaces.Models
{
    /// <summary>
    /// Assets are things you can use to help you get things done
    /// An asset is:
    /// - Not a place or a person
    /// - Usually attached to a place or person
    /// - Useful e.g. an source of income, a set of tools, a contact in the police
    /// Assets may also be clues in an investigation
    /// </summary>
    public class Asset
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}