namespace GraduationProjectAlpha.Dtos.Course
{
    public class SectionDto
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int Order { get; set; }
        public List<ModuleDto> ModuleDtos { get; set; }
    }
}
