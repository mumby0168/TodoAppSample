using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using WpfApp2.Interfaces;
using WpfApp2.Models;
using WpfApp2.Views;

namespace WpfApp2.ViewModels
{
    public class TodoItemsViewModel
    {
        private readonly ITodoManager _todoManager;
        private readonly IViewNavigator _viewNavigator;

        public TodoItemsViewModel(ITodoManager todoManager, IViewNavigator viewNavigator)
        {
            _todoManager = todoManager;
            _viewNavigator = viewNavigator;
            CompleteTaskCommand = new DelegateCommand<object>(CompleteTask);
        }

        public ObservableCollection<TodoItem> TodoItems
        {
            get => _todoManager.CurrentTodoItems;
        }

        public DelegateCommand<object> CompleteTaskCommand { get; set; }

        public void CompleteTask(object id)
        {
            var todoItem = _todoManager.CurrentTodoItems.FirstOrDefault(item => item.Id == (Guid)id);

            if(todoItem == null) return;
            
            _todoManager.CompleteTodoItem(todoItem);

            _viewNavigator.Navigate("MainRegion", typeof(DoneItemsView));
        }
        
    }
}
