using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Robot
{
    public class TacticsSettingsModel: BindableBase
    {
        /// <summary>
        /// 序号
        /// </summary>
        private int serialNo;
        public int SerialNo
        {
            get { return serialNo; }
            set 
            {
                serialNo = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 巡检路线
        /// </summary>
        private string route;
        public string Route 
        {
            get { return route; }
            set 
            {
                route = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 巡检机器人
        /// </summary>
        private string robotName;
        public string RobotName
        {
            get { return robotName; }
            set 
            {
                robotName = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 巡检速度
        /// </summary>
        private string speed;
        public string Speed
        {
            get { return speed; }
            set 
            {
                speed = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 巡检区间
        /// </summary>
        private string interval;
        public string Interval
        {
            get { return interval; }
            set 
            {
                interval = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 巡检模式
        /// </summary>
        private string model;
        public string Model
        {
            get { return model; }
            set 
            {
                model = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 巡检状态
        /// </summary>
        private string state;
        public string State
        {
            get { return state; }
            set 
            {
                state = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 立即启用
        /// </summary>
        private string enableNow;
        public string EnableNow
        {
            get { return enableNow; }
            set 
            {
                enableNow = value;
                RaisePropertyChanged();
            }
        }


    }
}
