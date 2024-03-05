namespace GraduationProjectAlpha.Entities
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public string CreatedBy { get; set; } = "Admin";
		public DateTime? ModifiedAt { get; set; } = null;
		public string ModifiedBy { get; set; } = "Admin";
		public bool IsDeleted { get; set; }
	}
}
