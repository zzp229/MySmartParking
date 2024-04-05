using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartParking.Client.MainModule.Models
{
    public class MenuItemModel : BindableBase
    {
        public string MenuIcon { get; set; }
        public string MenuHeader { get; set; }
        public string TargetView { get; set; }

        private bool _isExpanded;

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { SetProperty(ref _isExpanded, value); }
        }

        public List<MenuItemModel> Children { get; set; }

        public ICommand OpenViewCommand
        {
            get => new DelegateCommand(() =>
            {
                if ((this.Children == null || this.Children.Count == 0) &&
                    !string.IsNullOrEmpty(this.TargetView))
                {
                    // 页面跳转
                    _regionManager.RequestNavigate("MainContentRegion", this.TargetView);  // 更换区域导航
                }
                else
                    this.IsExpanded = !this.IsExpanded;
            });
        }
        IRegionManager _regionManager = null;
        // 构造方法注入区域管理
        public MenuItemModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
