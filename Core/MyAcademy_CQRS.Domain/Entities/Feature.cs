namespace MyAcademyCQRS.Core.Domain.Entities
{
    public class Feature:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StepNumber { get; set; }
    }
}
