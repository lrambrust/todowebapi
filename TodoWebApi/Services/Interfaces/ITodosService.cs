using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWebApi.Models;
using TodoWebApi.ViewModels;

namespace TodoWebApi.Services.Interfaces
{
    public interface ITodosService
    {
        Task<IList<Todo>> GetTodosAsync();
        Task<Todo> GetTodoByIdAsync(int id);
        Task<Todo> CreateTodoAsync(CreateTodoViewModel todo);
        Task UpdateTodoAsync(UpdateTodoViewModel todoViewModel, int id);
        Task DeleteTodoAsync(int id);
    }
}
