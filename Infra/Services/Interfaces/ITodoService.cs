using Models.Dtos;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Services.Interfaces
{
    public interface ITodoService
    {
        Task<IList<Todo>> GetTodosAsync();
        Task<Todo> GetTodoByIdAsync(int id);
        Task<Todo> CreateTodoAsync(CreateTodoDto todo);
        Task UpdateTodoAsync(UpdateTodoDto todoViewModel, int id);
        Task DeleteTodoAsync(int id);
    }
}
