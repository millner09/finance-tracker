namespace FinanceTracker.Api.Accounts
{
    /// <summary>
    /// A class that represents an account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// The id of the account
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the account.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The description of the account.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        // TODO: Make this an enum
        /// <summary>
        /// The type of the account (e.g., "savings", "checking").
        /// </summary>
        public string Type { get; set; } = string.Empty;
    }
}
