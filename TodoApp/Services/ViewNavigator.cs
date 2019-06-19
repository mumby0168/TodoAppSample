using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Regions;
using Unity;
using WpfApp2.Interfaces;

namespace WpfApp2.Services
{
    public class ViewNavigator : IViewNavigator
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _containerProvider;

        public ViewNavigator(IRegionManager regionManager, IUnityContainer containerProvider)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
        }

        public void Navigate(string regionName, Type viewType)
        {
            RegionManager.UpdateRegions();
            IRegion region = _regionManager.Regions[regionName];
            ClearRegions();
            var view = _containerProvider.Resolve(viewType);
            region.Add(view);
        }

        public void ClearRegions()
        {
            foreach (var region in _regionManager.Regions)
            {
                foreach (var activeView in region.ActiveViews)
                {
                    var disposableView = activeView as IDisposable;
                    if (disposableView != null)
                    {
                        disposableView.Dispose();
                    }                        
                }

                region.RemoveAll();
            }
        }
    }
}
