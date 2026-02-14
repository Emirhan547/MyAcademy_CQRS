namespace MyAcademyCQRS.Core.Application.Features.Results.ContactMessageResults
{
    public class GetAllContactMessagesQueryResult
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
