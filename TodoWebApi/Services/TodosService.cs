using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWebApi.Data;
using TodoWebApi.Models;
using TodoWebApi.Services.Interfaces;
using TodoWebApi.ViewModels;

namespace TodoWebApi.Services
{
    public class TodosService : ITodosService
    {
        private readonly AppDbContext _context;

        public TodosService(AppDbContext context)
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

        public async Task<Todo> CreateTodoAsync(CreateTodoViewModel todo)
        {
            var newTodo = new Todo(todo.Title);

            await _context.Todos.AddAsync(newTodo);
            await _context.SaveChangesAsync();

            return newTodo;
        }

        public async Task UpdateTodoAsync(UpdateTodoViewModel todoViewModel, int id)
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
