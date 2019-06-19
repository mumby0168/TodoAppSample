using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Interfaces
{
    public interface IViewNavigator
    {
        void Navigate(string regionName, Type viewType);

        void ClearRegions();
    }
}
