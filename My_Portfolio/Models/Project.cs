using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? SrcImage { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }

        [Display(Name ="Project URL")]
        public string? MoreDetailsUrl { get; set; }
    }
}
