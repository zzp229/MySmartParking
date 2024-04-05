using Microsoft.EntityFrameworkCore;
using SmarkParking.Server.IService;
using SmartParking.Server.IEFContext;
using System;

namespace SmarkParking.Server.Service
{
    public class LoginService : ServiceBase, ILoginService
    {


        public LoginService(IEFContext eFContext) : base(eFContext)
        {

        }


    }
}
