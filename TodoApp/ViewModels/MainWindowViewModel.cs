using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Commands;
using Prism.Regions;
using WpfApp2.Interfaces;
using WpfApp2.Models;
using WpfApp2.Views;

namespace WpfApp2.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IViewNavigator _viewNavigator;

        public MainWindowViewModel(IRegionManager regionManager, IViewNavigator viewNavigator)
        {
            _regionManager = regionManager;
            _viewNavigator = viewNavigator;
            RegisterViewsWithRegions();
            NavigateTodoItemsCommand = new DelegateCommand(NavigateTodoItems);
            NavigateAddTodoCommand = new DelegateCommand(NavigateAddTodo);
            NavigateHomeCommand = new DelegateCommand(NavigateHome);
            NavigateDoneItemsCommand = new DelegateCommand(NavigateDoneItems);
        }

        private void RegisterViewsWithRegions()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(HomeView));
        }

        public DelegateCommand NavigateTodoItemsCommand { get; set; }

        private void NavigateTodoItems()
        {
            _viewNavigator.Navigate("MainRegion", typeof(TodoItemsView));
        }

        public DelegateCommand NavigateAddTodoCommand { get; set; }

        private void NavigateAddTodo()
        {
            _viewNavigator.Navigate("MainRegion", typeof(AddItemView));
        }

        public DelegateCommand NavigateHomeCommand { get; set; }

        private void NavigateHome()
        {
            _viewNavigator.Navigate("MainRegion", typeof(HomeView));
        }

        public DelegateCommand NavigateDoneItemsCommand { get; set; }

        public void NavigateDoneItems()
        {
            _viewNavigator.Navigate("MainRegion", typeof(DoneItemsView));
        }
    }
}
