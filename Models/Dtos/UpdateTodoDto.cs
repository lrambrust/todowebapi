using System.ComponentModel.DataAnnotations;

namespace Models.Dtos
{
    public class UpdateTodoDto
    {
        [Required]
        public string Title { get; set; }
        public bool Done { get; set; }
    }
}
