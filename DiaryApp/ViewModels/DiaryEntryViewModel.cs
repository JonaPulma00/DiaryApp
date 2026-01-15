using System.ComponentModel.DataAnnotations;

namespace DiaryApp.ViewModels
{
    public class DiaryEntryViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title can not be empty")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content can not be empty")]
        [StringLength(500, ErrorMessage = "Content can't be larger than 500 characters.")]
        public string Content { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
