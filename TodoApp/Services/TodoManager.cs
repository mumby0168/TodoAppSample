using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Interfaces;
using WpfApp2.Models;

namespace WpfApp2.Services
{
    public class TodoManager : ITodoManager
    {
        public TodoManager()
        {
            DoneTodoItems = new ObservableCollection<TodoItem>();        
            CurrentTodoItems = new ObservableCollection<TodoItem>();
        }

        public ObservableCollection<TodoItem> DoneTodoItems { get; }
        public ObservableCollection<TodoItem> CurrentTodoItems { get; }
        public void AddNewTodo(TodoItem todoItem)
        {
            CurrentTodoItems.Add(todoItem);
        }

        public void CompleteTodoItem(TodoItem todoItem)
        {
            CurrentTodoItems.Remove(todoItem);
            todoItem.CompleteTask();
            DoneTodoItems.Add(todoItem);
        }
    }
}
