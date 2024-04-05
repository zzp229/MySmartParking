using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.IDAL
{
    public interface IUserDal
    {
        Task<string> GetAll();
        Task<string> GetRolesByUserId(int userId);

        Task ResetPassword(string userId);
        Task SaveUser(string data);
    }
}
