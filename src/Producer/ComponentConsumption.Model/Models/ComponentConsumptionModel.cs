namespace ComponentConsumption.Model.Models
{
    public class ComponentConsumptionModel
    {
        public int Id { get; init; }
        public string BoardSerial { get; init; } = string.Empty;
        public string BoardType { get; init; } = string.Empty;
        public string ComponentDescription { get; init; } = string.Empty;
        public int Quantity { get; init; }
        public int IsConsumed { get; init; }

    }
}
