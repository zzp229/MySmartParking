﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.DAL
{
    public class WebDataAccess
    {
        protected string domain = "http://localhost:5000/api/";

        public Task<string> GetDatas(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var resp = client.GetAsync(url).GetAwaiter().GetResult();  // 从api中获取数据
                return resp.Content.ReadAsStringAsync();
            }
        }

        // 处理post请求过来的多个数据
        private MultipartFormDataContent GetFormData(Dictionary<string, HttpContent> contents)
        {
            var postContent = new MultipartFormDataContent();
            string boundary = string.Format($"-------{DateTime.Now.Ticks.ToString("x")}------");
            postContent.Headers.Add("ContentType", $"muiltipart/form-data,boundary={boundary}");

            foreach (var item in contents)
            {
                postContent.Add(item.Value, item.Key);
            }

            return postContent;
        }

        // 这是多个获取多个formData参数的
        public Task<string> PostDatas(string url, Dictionary<string, HttpContent> contents)
        {
            using (HttpClient client = new HttpClient())
            {
                var resp = client.PostAsync(url, this.GetFormData(contents)).GetAwaiter().GetResult();  // 发送Post请求
                return resp?.Content.ReadAsStringAsync();   // 返回结果
            }
        }

        // 这个是返回一个formData的
        public Task<string> PostDatas(string url, HttpContent contents)
        {
            using (HttpClient client = new HttpClient())
            {
                var resp = client.PostAsync(url, contents).GetAwaiter().GetResult();
                return resp.Content.ReadAsStringAsync();
            }
        }
    }
}
