namespace Course.Models
{
    public class ChildrensData
    {
        public string name {  get; set; }
        public IEnumerable<Gradebooks> grades { get; set; }
    }
}
