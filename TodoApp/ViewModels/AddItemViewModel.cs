using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using WpfApp2.Interfaces;
using WpfApp2.Models;
using WpfApp2.Properties;
using WpfApp2.Views;

namespace WpfApp2.ViewModels
{
    public class AddItemViewModel : INotifyPropertyChanged
    {
        private readonly ITodoManager _todoManager;
        private readonly IViewNavigator _viewNavigator;
        private string _name;
        private DateTime _completedBy;

        public AddItemViewModel(ITodoManager todoManager, IViewNavigator viewNavigator)
        {
            _todoManager = todoManager;
            _viewNavigator = viewNavigator;
            AddCommand = new DelegateCommand(Add);
            CompletedBy = DateTime.Now;

        }

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public DateTime CompletedBy
        {
            get => _completedBy;
            set
            {
                if (value.Equals(_completedBy)) return;
                _completedBy = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand AddCommand { get; set; }

        public void Add()
        {
            var todo = new TodoItem(Name, CompletedBy);
            _todoManager.AddNewTodo(todo);
            _viewNavigator.Navigate("MainRegion", typeof(TodoItemsView));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
