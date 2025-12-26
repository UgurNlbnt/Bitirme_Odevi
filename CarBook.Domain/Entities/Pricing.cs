namespace CarBook.Domain.Entities
{
    public class Pricing
    {
        public int PricingId { get; set; }
        public string Name { get; set; }
        List<CarPricing> Cars { get; set; }
    }
}
