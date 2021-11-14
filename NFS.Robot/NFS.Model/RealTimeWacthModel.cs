using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model
{
    public class RealTimeWacthModel
    {
        /// <summary>
        /// 当前托辊编号
        /// </summary>
        public string CurrentRoller { set; get; }
        /// <summary>
        /// 托辊温度
        /// </summary>
        public string RollerTemperature { set; get; }
        /// <summary>
        /// 运动速度
        /// </summary>
        public string Speed { set; get; }
        /// <summary>
        /// 当前坡度
        /// </summary>
        public string CurrentSlope { set; get; }
        /// <summary>
        /// 当前电量
        /// </summary>
        public string Buttery { set; get; }
        /// <summary>
        /// 内部温度
        /// </summary>
        public string InternalTemperature { set; get; }
        /// <summary>
        /// 视频流地址
        /// </summary>
        public string url { set; get; }

    }
}
