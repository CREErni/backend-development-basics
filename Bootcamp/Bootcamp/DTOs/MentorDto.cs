namespace Bootcamp.DTOs
{
    public class MentorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Expertise { get; set; }
        public List<string> Bootcampers { get; set; }
    }

    public class CreateMentorDto
    {
        public string Name { get; set; }
        public string Expertise { get; set; }
    }

}
