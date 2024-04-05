using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SmartParking.Client.MainModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.MainModule
{
    /// <summary>
    /// 这个类要继承IModule，要用需要到App.xaml中重写ConfigureModuleCatalog
    /// </summary>
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // 初始化的时候，添加一个组件到对应的区域
            // 比如 左侧菜单栏
            // 需要一个RegionManager

            var regionManager = containerProvider.Resolve<IRegionManager>();    // 通过ioc获取regionManager对象
            regionManager.RegisterViewWithRegion("LeftMenuTreeRegion", typeof(TreeMenuView));   // 向区域LeftMenuTreeRegion放入TreeMenuView
            regionManager.RegisterViewWithRegion("MainHeaderRegion", typeof(MainHeaderView));

        }

        // 注册要放到Region的控件（ViewModel会自动绑定，这样可以在MainView的区域中显示）
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<TreeMenuView>();
            containerRegistry.Register<MainHeaderView>();
        }
    }
}
