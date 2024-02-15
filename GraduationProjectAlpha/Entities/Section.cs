namespace GraduationProjectAlpha.Entities
{
    public class Section
    {
        public int SectionId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public int DurationInMinutes { get; set; }
        public Course Course { get; set; }
        public List<Module> Modules { get; set; }
    }
}