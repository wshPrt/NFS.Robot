using NFS.Commons;
using NFS.Commons.HttpRequest;
using NFS.Model.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.Interface
{
    /// <summary>
    /// 登陆方法
    /// </summary>
    public partial class SignIn : ISignInterface
    {
        public async Task<LoginModel.root> AccountLogin(string userName, string passWord)
        {
            if (string.IsNullOrEmpty(userName)) throw new Exception("登陆用户不能为空");
            if (string.IsNullOrEmpty(passWord)) throw new Exception("登陆密码不能为空");
            var http = new HttpExtend();
            var value = "7c24156b4d7c7542f26d39bb9e7ab857";

            var headers = new Dictionary<string, string>();
            headers.Add("token", value);
            var result = await http.Post<dynamic, LoginModel.root>(Urls.LOGIN_URL +"?appkey=5272939369"+ "&username=" + userName+"&password=" + passWord, null, null);
            return result;
        }
    }
}
