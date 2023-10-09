namespace InventoryService.Domain.Model;

public class FlockIdentity
{

    public string PublicId { get; set; } = string.Empty;
    public string FarmNo { get; set; } = string.Empty;
    public string FarmName { get; set; } = string.Empty;
    public string FlockNo { get; set; } = string.Empty;
    public string HouseNo { get; set; } = string.Empty;
    public string PenNo { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public DateTime? DateSold { get; set; } = null;
    public DateTime? DateSoldWithExtraDays { get; set; } = null;
    public string PrimaryHatchery { get; set; } = string.Empty;
    public DateTime DatePlaced { get; set; }

}
