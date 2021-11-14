using NFS.Commons.Base;
using NFS.Model.Robot;
using NFS.Robot.Interface;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.ViewModels
{
   public class ElectricityStyleViewModel:BindableBase
    {
        public ElectricityStyleViewModel()
        {
            RobotInfo = new RobotInfoModel();

        }
        private RobotInfoModel _robotInfo;
        public RobotInfoModel RobotInfo
        {
            get { return _robotInfo; }
            set { _robotInfo = value; }
        }
        public void SetSubscribe()
        {
            EventAggregatorRepository
                .GetInstance()
                .eventAggregator
                .GetEvent<GetInputMessages>()
                .Subscribe(ReceiveMessage, ThreadOption.UIThread, true);
        }
        public void ReceiveMessage(string messageData)
        {
            RobotInfo.Battery = Convert.ToInt32(messageData);
        }
      
    }
}
