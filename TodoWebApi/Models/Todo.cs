using System;

namespace TodoWebApi.Models
{
    public class Todo
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public bool Done { get; private set; } = false;
        public DateTime Date { get; private set; } = DateTime.Now;

        public Todo()
        {
        }
        public Todo(string title)
        {
            Title = title;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void IsDone(bool done)
        {
            Done = done;
        }
    }
}
