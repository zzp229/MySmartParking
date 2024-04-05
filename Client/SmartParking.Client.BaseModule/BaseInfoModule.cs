using Prism.Ioc;
using Prism.Modularity;
using SmartParking.Client.BaseModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.BaseModule
{
    public class BaseInfoModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 用上这个需要下载Prism.Wpf
            containerRegistry.RegisterForNavigation<UserManagementView>();    // test是做一个标记方便查找关闭
            containerRegistry.RegisterDialog<ModifyUserDialog>();
        }
    }
}
