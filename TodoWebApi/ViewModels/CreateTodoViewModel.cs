using System.ComponentModel.DataAnnotations;

namespace TodoWebApi.ViewModels
{
    public class CreateTodoViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
