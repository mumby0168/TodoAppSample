using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Interfaces;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class DoneItemsViewModel
    {
        private readonly ITodoManager _todoManager;

        public DoneItemsViewModel(ITodoManager todoManager)
        {
            _todoManager = todoManager;
        }

        public ObservableCollection<TodoItem> TodoItems
        {
            get => _todoManager.DoneTodoItems;
        }   
    }
}
