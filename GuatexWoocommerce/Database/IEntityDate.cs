namespace GuatexWoocommerce.Database
{
    public interface IEntityDate
    {
        /// <summary>
        /// Created at
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Updated at
        /// </summary>
        DateTime UpdatedAt { get; set; }
    }
}
