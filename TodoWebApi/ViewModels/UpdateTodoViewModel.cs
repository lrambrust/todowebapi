using System.ComponentModel.DataAnnotations;

namespace TodoWebApi.ViewModels
{
    public class UpdateTodoViewModel
    {
        [Required]
        public string Title { get; set; }
        public bool Done { get; set; }
    }
}
