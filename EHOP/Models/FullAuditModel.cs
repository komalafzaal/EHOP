namespace EHOP.Models
{
	public  class FullAuditModel 
	{
		public int Id { get; set; }
		public string? createdByUserName { get; set; }
		public DateTime CreatedDate { get; set; }
		public string? LastModifiedUserId { get; set; }
		public DateTime lastModifiedDate { get; set; }
		public bool IsActive { get; set; }
	}
}
