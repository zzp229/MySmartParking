using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmarkParking.Server.IService;
using System.Security.Cryptography;
using System.Text;
using System;
using SmartParking.Server.Models;
using System.Linq;
using System.Collections.Generic;
using IConfiguration;
using System.Text.Json;

namespace SmartParking.Server.Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IMenuService _menuService;
        private readonly IUserService _userService;
        private readonly IUtils _utils;

        public UserController(ILoginService loginService, IMenuService menuService, IUserService userService, IUtils utils)
        {
            this._loginService = loginService;
            this._menuService = menuService;
            this._userService = userService;
            this._utils = utils;
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromForm] string username, [FromForm] string password)
        {
            string pwd = _utils.GetMD5Str(_utils.GetMD5Str(password) + "|" + username);
            var users = _loginService.Query<SysUserInfo>(u => u.UserName == username && u.Password == pwd);

            if (users?.Count() > 0)
            {
                var userInfo = users.ToList();
                SysUserInfo sysUserInfo = userInfo[0];

                // 菜单
                // 需要进行权限管理
                // menu-role_menu-role-role_user-user
                List<MenuInfo> menus = _menuService.GetMenusByUserId(sysUserInfo.UserId);
                sysUserInfo.Menus = menus;  // 当前用户的菜单

                return Ok(sysUserInfo);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// 获取所有的用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public JsonResult GetUsers()
        {
            return Json(_userService.Query<SysUserInfo>(u => true));
        }


        // 改为通用类中注入
        //private string GetMd5Str(string inputStr)
        //{
        //    if (string.IsNullOrEmpty(inputStr)) return "";

        //    byte[] result = Encoding.Default.GetBytes(inputStr);    //tbPass为输入密码的文本框
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] output = md5.ComputeHash(result);
        //    return BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本的文本框
        //}


        [HttpGet("roles/{userId}")]
        public JsonResult GetRolesByUserId(int userId)
        {
            return Json(_userService.GetRolesByUserId(userId)); // Service中直接从EFCore中查的
        }

        [HttpPost]
        [Route("resetpwd")]
        public IActionResult ResetPassword([FromForm] IFormCollection form)
        {
            _userService.ResetPassword(int.Parse(form["userId"]));
            return Ok();
        }

        [HttpPost]
        [Route("save")]
        public IActionResult UpdateUserInfo([FromBody] JsonElement data)
        {
            _userService.SaveUser(data.ToString());
            return Ok(data);
        }
    }
}
