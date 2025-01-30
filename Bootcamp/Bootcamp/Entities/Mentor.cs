namespace Bootcamp.Entities
{
    public class Mentor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Expertise { get; set; }
        public ICollection<Bootcamper> Bootcampers { get; set; }
    }

}
