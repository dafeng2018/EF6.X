namespace One2One
{
    public class StudentContact
    {
        public long Id { get; set; }
        public string ContactNumber { get; set; }
        public virtual Student Student { get; set; }
    }
}