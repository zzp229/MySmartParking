using Prism.Commands;
using Prism.Mvvm;
using SmartParking.Client.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SmartParking.Client.Start.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        // 构造函数注入BLL
        public LoginViewModel(ILoginBLL loginBLL)
        {
            this._loginBLL = loginBLL;
        }
        private string _userName = "admin";

        public string UserName
        {
            get { return _userName; }
            set { SetProperty<string>(ref _userName, value); }
        }


        private string _password = "123456";

        public string Password
        {
            get { return _password; }
            set { SetProperty<string>(ref _password, value); }
        }

        private string _errorMsg;
        ILoginBLL _loginBLL;

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { SetProperty<string>(ref _errorMsg, value); }
        }



        // 登录命令
        public ICommand LoginCommand
        {
            get => new DelegateCommand<object>(OnLogin);
        }

        private void OnLogin(object obj)
        {
            try
            {
                this.ErrorMsg = "";
                if (string.IsNullOrEmpty(this.UserName))
                {
                    throw new Exception("请输入用户名");
                }
                if (string.IsNullOrEmpty(this.Password))
                {
                    throw new Exception("请输入密码");
                }

                // 登录操作
                if (_loginBLL.Login(this.UserName, this.Password).GetAwaiter().GetResult())
                {
                    // 关闭登录窗口，并且DialogResult返回True给主窗口；
                    (obj as Window).DialogResult = true;
                }
                else
                {
                    throw new Exception("用户名或密码错误");
                }
            }
            catch (Exception ex)
            {
                this.ErrorMsg = "登录失败!" + ex.Message;   // 拼凑成登录的提示
            }
        }
    }
}
