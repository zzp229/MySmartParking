using System;

namespace IConfiguration
{
    public interface IConfiguration
    {
        string Read(string key);
    }
}
