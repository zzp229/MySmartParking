using Prism.Regions;
using SmartParking.Client.Entity;
using SmartParking.Client.MainModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.MainModule.ViewModels
{
    public class TreeMenuViewModel
    {
        public List<MenuItemModel> Menus { get; set; } = new List<MenuItemModel>();

        // 列表，没有树形结构
        private List<MenuEntity> origMenMenus = null;
        private readonly IRegionManager _regionManager;

        public TreeMenuViewModel(IRegionManager regionManager)
        {
            // 需要获取菜单数据
            origMenMenus = GlobalEntity.CurrentUserInfo?.Menus;

            this.FillMenus(Menus, 0);
            this._regionManager = regionManager;
        }


        /// <summary>
        /// 递归遍历出所有的菜单
        /// </summary>
        /// <param name="menus"></param>
        /// <param name="parentId"></param>
        private void FillMenus(List<MenuItemModel> menus, int parentId)
        {
            var sub = origMenMenus.Where(m => m.ParentId == parentId).OrderBy(m => m.Index);

            if (sub.Count() > 0)
            {
                foreach (var item in sub)
                {
                    MenuItemModel mm = new MenuItemModel(_regionManager)
                    {
                        MenuHeader = item.MenuHeader,
                        MenuIcon = item.MenuIcon,
                        TargetView = item.TargetView,
                    };
                    menus.Add(mm);

                    FillMenus(mm.Children = new List<MenuItemModel>(), item.MenuId);
                }
            }
        }


    }
}
