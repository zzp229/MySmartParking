﻿using System;
using System.Collections.Generic;

namespace SmartParking.Client.Entity
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string UserIcon { get; set; }
        public int Age { get; set; }

        public List<MenuEntity> Menus { get; set; } // 这个用户的菜单
    }
}
