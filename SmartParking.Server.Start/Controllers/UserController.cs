using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmarkParking.Server.IService;
using System.Security.Cryptography;
using System.Text;
using System;
using SmartParking.Server.Models;
using System.Linq;

namespace SmartParking.Server.Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public UserController(ILoginService loginService)
        {
            this._loginService = loginService;
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromForm] string username, [FromForm] string password)
        {
            string pwd = GetMd5Str(GetMd5Str(password) + "|" + username);
            var users = _loginService.Query<SysUserInfo>(u => u.UserName == username && u.Password == pwd);

            if (users?.Count() > 0)
            {
                var userInfo = users.ToList();
                SysUserInfo sysUserInfo = userInfo[0];

                // 菜单

                return Ok(sysUserInfo);
            }
            else
            {
                return NoContent();
            }
        }


        private string GetMd5Str(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr)) return "";

            byte[] result = Encoding.Default.GetBytes(inputStr);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本的文本框
        }
    }
}
