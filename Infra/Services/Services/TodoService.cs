using Infra.Data;
using Infra.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Services.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _context;

        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Todo>> GetTodosAsync()
        {
            return await _context.Todos.AsNoTracking().ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            return await _context.Todos.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Todo> CreateTodoAsync(CreateTodoDto todo)
        {
            var newTodo = new Todo(todo.Title);

            await _context.Todos.AddAsync(newTodo);
            await _context.SaveChangesAsync();

            return newTodo;
        }

        public async Task UpdateTodoAsync(UpdateTodoDto todoViewModel, int id)
        {
            var todoToUpdate = await _context.Todos.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

            todoToUpdate.SetTitle(todoViewModel.Title);
            todoToUpdate.IsDone(todoViewModel.Done);

            _context.Todos.Update(todoToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }
    }
}
