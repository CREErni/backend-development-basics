namespace Bootcamp.Entities
{
    public class Bootcamper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
    }

}
