using System.ComponentModel.DataAnnotations;

namespace Models.Dtos
{
    public class CreateTodoDto
    {
        [Required]
        public string Title { get; set; }
    }
}
