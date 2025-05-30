using System.ComponentModel.DataAnnotations;

namespace MOJTask.Models
{
    public class CaseWorkerTask
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        [Required]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
    }
}
