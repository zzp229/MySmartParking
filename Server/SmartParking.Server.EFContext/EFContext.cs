using IConfiguration;
using SmartParking.Server.EFCore;
using SmartParking.Server.IEFContext;
using System;

namespace SmartParking.Server.EFContext
{
    /// <summary>
    /// 获取EFCoreContext对象
    /// </summary>
    public class EFContext : IEFContext.IEFContext
    {
        IConfiguration.IConfiguration _configuration;

        public EFContext(IConfiguration.IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EFCoreContext CreateDBContext()
        {
            return new EFCoreContext(_configuration.Read("DBConnectStr"));
        }
    }
}
