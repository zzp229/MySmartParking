using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using SmartParking.Client.BaseModule.Models;
using SmartParking.Client.Common;
using SmartParking.Client.IBLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Unity;

namespace SmartParking.Client.BaseModule.ViewModels
{
    public class UserManagementViewModel : ViewModelBase // 这个是Prism提供的导航
    {
        private readonly IUnityContainer _unityContainer;
        private readonly IUserBLL _userBLL;
        private readonly IDialogService _dialogService;

        public ObservableCollection<UserModel> UserList { get; set; } = new ObservableCollection<UserModel>();

        // 父类有需要构造函数注入的
        public UserManagementViewModel(IUnityContainer unityContainer, IRegionManager regionManager, IUserBLL userBLL,
            IDialogService dialogService) : base(unityContainer, regionManager)
        {
            this.PageTitle = "系统用户管理";

            this._unityContainer = unityContainer;
            this._userBLL = userBLL;
            this._dialogService = dialogService;
        }


        public override void Refresh()
        {
            // 用户信息刷新
            UserList.Clear();
            Task.Run(() =>
            {
                var users = _userBLL.GetAll().GetAwaiter().GetResult();

                foreach (var item in users)
                {
                    UserModel userModel = new UserModel
                    {
                        Index = users.IndexOf(item) + 1,
                        UserId = item.UserId,
                        UserName = item.UserName,
                        UserIcon = "pack://application:,,,/SmartParking.Client.Assets;component/Images/Logo.jpg",
                        Age = item.Age,
                        Password = item.Password,
                        RealName = item.RealName
                    };
                    // 用户角色
                    var roles = _userBLL.GetRolesByUserId(userModel.UserId).GetAwaiter().GetResult();
                    // 填充
                    roles?.ForEach(r => userModel.Roles.Add(new RoleModel
                    {
                        RoleId = r.roleId,
                        RoleName = r.roleName,
                        State = r.state
                    }));

                    // 编辑
                    userModel.EditCommand = new DelegateCommand<object>(EditItem);
                    // 删除
                    userModel.DeleteCommand = new DelegateCommand<object>(DeleteItem);
                    // 角色分配
                    userModel.RoleCommand = new DelegateCommand<object>(SetRoles);
                    // 重置密码
                    userModel.PwdCommand = new DelegateCommand<object>(SetPassword);

                    // 更新UI控件的记得要回到UI线程中
                    _unityContainer.Resolve<Dispatcher>().Invoke(() =>
                    {
                        UserList.Add(userModel);
                    });

                }
            });
        }



        public override void AddItem()
        {

        }

        private void EditItem(object obj)
        {
            DialogParameters param = new DialogParameters();
            param.Add("model", obj as UserModel);
            _dialogService.ShowDialog("ModifyUserDialog", param, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    System.Windows.MessageBox.Show("数据保存成功", "提示");
                    this.Refresh();
                }
            });
        }

        private void DeleteItem(object obj)
        {
            if (System.Windows.MessageBox.Show("是否确定删除此用户信息？", "提示", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) == System.Windows.MessageBoxResult.Yes)
            {
                // 把用户的状态的置成不可用（逻辑删除），也可以进行数据物理删除
                //var model = obj as UserInfoModel;
                //if (model != null)
                //    await _userBLL.ChangeState(model.UserId, 0);

                this.Refresh();
            }
        }

        private void SetRoles(object obj)
        {

        }

        private void SetPassword(object obj)
        {
            Task.Run(async () =>
            {
                await _userBLL.ResetPassword(obj.ToString());   // 这里有传过来的Id
                System.Windows.MessageBox.Show("密码已重置", "提示");
            });
        }
    }
}
