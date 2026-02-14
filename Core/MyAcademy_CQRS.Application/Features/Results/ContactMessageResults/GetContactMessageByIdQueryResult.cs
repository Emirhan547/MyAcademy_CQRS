namespace MyAcademyCQRS.Core.Application.Features.Results.ContactMessageResults
{
    public class GetContactMessageByIdQueryResult
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
