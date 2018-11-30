namespace _03_03
{
    public class Order : BaseEntity

    {
        public byte Quantity { get; set; }
        public int Price { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}