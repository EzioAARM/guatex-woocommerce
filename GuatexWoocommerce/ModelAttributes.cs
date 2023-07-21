namespace GuatexWoocommerce
{
    public class ModelAttributes : Attribute
    {
        /// <summary>
        /// Indiates if the property should be included in the DataGridView
        /// </summary>
        public bool IncludeInView { get; set; }

        /// <summary>
        /// Indicates the width of the column in the DataGridView
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Indicates the position of the column in the DataGridView
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Indicates the title of the column in the DataGridView
        /// </summary>
        public string Title { get; set; }
    }
}
