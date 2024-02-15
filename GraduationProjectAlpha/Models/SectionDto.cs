using System;

public class SectionDto
{
	public string Name { get; set; }
	public IEnumerable<ModuleDto> Modules { get; set; }
}