using Prism.Ioc;
using Prism.Modularity;
using SmartParking.Client.BLL;
using SmartParking.Client.DAL;
using SmartParking.Client.IBLL;
using SmartParking.Client.IDAL;
using SmartParking.Client.MainModule;
using SmartParking.Client.Start.Views;
using System.Windows;
using System.Windows.Threading;

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

        // 注册好了就能通过构造方法获取了
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<Dispatcher>(() => Application.Current.Dispatcher);   // 这个是修改控件的线程

            containerRegistry.Register<ILoginDal, LoginDal>();
            containerRegistry.Register<IUserDal, UserDal>();

            containerRegistry.Register<ILoginBLL, LoginBLL>();
            containerRegistry.Register<IUserBLL, UserBLL>();
        }


        // 添加模块
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // 可以改为自动扫描
            moduleCatalog.AddModule<MainModule.MainModule>();
            moduleCatalog.AddModule<BaseModule.BaseInfoModule>();
        }
    }
}
