using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_8._2.Models
{
    public static class Auth
    {
        public static bool CanLogin(string login, string pass) => login == "admin" && pass == "admin" || login == "markus" && pass == "qwerty";
    }
}