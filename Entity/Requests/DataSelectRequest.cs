namespace Entity.Requests
{
    /// <summary>
    /// Represents a Request for selection data.
    /// This class is used to encapsulate the data for items to be displayed in a selection list or dropdown.
    /// </summary>
    public class DataSelectRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier for the selection item.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the display text for the selection item.
        /// This is the text that will be shown in a selection interface, such as a dropdown or list.
        /// </summary>
        public string DisplayText { get; set; } = null!;
    }
}
