using System;

namespace _02_04
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid Guid { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public double Double { get; set; }
        public double Double2 { get; set; }
        public float Float { get; set; }
        public DateTime CreatedTime { get; set; }

        public int BlogId { get; set; }
        public decimal Price { get; set; }
        public decimal Price1 { get; set; }
    }
}