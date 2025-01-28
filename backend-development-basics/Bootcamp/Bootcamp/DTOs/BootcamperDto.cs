namespace Bootcamp.DTOs
{
    public class BootcamperDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MentorName { get; set; }
    }

    public class CreateBootcamperDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int MentorId { get; set; }
    }

}
