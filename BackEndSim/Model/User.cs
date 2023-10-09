namespace InventoryService.Domain.Model
{
    public class User
    {
        public User() { }

        public string PublicId { get; init; } = string.Empty;
        public string UserPrincipalName { get; init; } = string.Empty;
    }
}
