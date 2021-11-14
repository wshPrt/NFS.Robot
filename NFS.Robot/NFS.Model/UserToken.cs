using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model
{
   public static class UserToken
    {
        /// <summary>
        /// Token
        /// </summary>
        public static string token { get; set; }
        /// <summary>
        /// 续航里程
        /// </summary>
        public static int mileage  { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public static decimal speed { get; set; }
        /// <summary>
        /// 电量
        /// </summary>
        public static int electricity { get; set;}
    }
}
