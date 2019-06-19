using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Interfaces
{
    public interface ITodoManager
    {
        ObservableCollection<TodoItem> DoneTodoItems { get; }

        ObservableCollection<TodoItem> CurrentTodoItems { get; }

        void AddNewTodo(TodoItem todoItem);

        void CompleteTodoItem(TodoItem todoItem);
    }
}
