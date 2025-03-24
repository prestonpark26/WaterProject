using System.ComponentModel.DataAnnotations;

namespace WaterProject.API.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string? ProjectType { get; set; }
        public string? ProjectRegionalProgram { get; set; }
        public int? ProjectImpact {  get; set; }
        public string? ProjectPhase { get; set; }
        public string? ProjectFunctionalityStatus { get; set; }
    }
}
