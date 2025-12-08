namespace Sequoia.Core.Models
{
    public class Note
    {
        uint Id { get; set; }
        public string Name { get; set; }
        public DateTime LastEdited { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        //public object Parent { get; set; }
    }
}
