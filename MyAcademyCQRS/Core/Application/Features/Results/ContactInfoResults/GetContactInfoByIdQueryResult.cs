namespace MyAcademyCQRS.Core.Application.Features.Results.ContactInfoResults
{
    public class GetContactInfoByIdQueryResult
    {
        public int Id { get; set; }
        public string BackgroundImageUrl { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OpeningHours { get; set; }
        public string HolidayHours { get; set; }
        public bool IsActive { get; set; }
    }
}