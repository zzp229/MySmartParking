using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SmartParking.Client.BaseModule.Models;
using SmartParking.Client.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartParking.Client.BaseModule.ViewModels
{
    public class ModifyUserDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "用户信息编辑";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        // 窗口传入参数
        public void OnDialogOpened(IDialogParameters parameters)
        {
            // 接收编辑状态：新增/编辑
            // 获取要编辑的用户信息
            MainModel = parameters.GetValue<UserModel>("model");    // 这个参数是窗口打开的时候传过来的
        }

        public UserModel MainModel { get => _mainModel; set { SetProperty<UserModel>(ref _mainModel, value); } }

        private UserModel _mainModel = new UserModel();
        private readonly IUserBLL _userBLL;

        // 确认
        public ICommand ConfirmCommand
        {
            get => new DelegateCommand(() =>
            {
                _userBLL.SaveUser(new Entity.UserEntity
                {
                    UserId = MainModel.UserId,
                    UserName = MainModel.UserName,
                    RealName = MainModel.RealName,
                    //UserIcon = MainModel.UserIcon?.Replace(System.Configuration.ConfigurationManager.AppSettings["api_domain"].ToString(), ""),
                    Password = MainModel.Password,
                    Age = MainModel.Age
                });

                // 这个是Action的传入参数
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));    // 关闭了就返回一个OK状态好像
            });
        }

        // 取消
        public ICommand CancelCommand
        {
            get => new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));    // 返回一个取消好像
            });
        }

        public ModifyUserDialogViewModel(IUserBLL userBLL)
        {
            this._userBLL = userBLL;
        }
    }
}
