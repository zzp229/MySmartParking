using Prism.Ioc;
using SmartParking.Client.BLL;
using SmartParking.Client.DAL;
using SmartParking.Client.IBLL;
using SmartParking.Client.IDAL;
using SmartParking.Client.Start.Views;
using System.Windows;

namespace SmartParking.Client.Start
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        // 初始化shell前
        protected override void InitializeShell(Window shell)
        {

            if (new LoginView().ShowDialog() == false)   // 登录窗口通过了再开
            {
                Application.Current?.Shutdown();
            }
            else
                base.InitializeShell(shell);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILoginDal, LoginDal>();
            containerRegistry.Register<ILoginBLL, LoginBLL>();
        }
    }
}
