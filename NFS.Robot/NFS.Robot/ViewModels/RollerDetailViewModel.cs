using NFS.Model.Robot;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.ViewModels
{
    public class RollerDetailViewModel : BindableBase, IDialogAware
    {
        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        public RollerDetailViewModel()
        {
            RollerDetailList = new ObservableCollection<RollerDetailModel>();
            InitData();
        }

        private ObservableCollection<RollerDetailModel> _rollerDetailList;
        public ObservableCollection<RollerDetailModel> RollerDetailList
        {
            get { return _rollerDetailList; }
            set
            {
                _rollerDetailList = value;
                RaisePropertyChanged();
            }
        }

        public bool CanCloseDialog()
        {
            return true;
        }
        public void OnDialogClosed()
        {

        }
        public void OnDialogOpened(IDialogParameters parameters)
        {

        }

        private async void InitData()
        {
            await Task.Run(() =>
            {
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        RollerDetailModel rollerDetail = new RollerDetailModel();
                        rollerDetail.Date = "2021-09-01";
                        rollerDetail.HighestTemperature = "50℃";
                        rollerDetail.LowestTemperature = "20℃";
                        rollerDetail.Count = 5;
                        rollerDetail.Average = "30℃";
                        rollerDetail.LastTemperatureTime = "22:22:30";
                        rollerDetail.LastTemperature = "30℃";
                        rollerDetail.CurrentState = "正常";
                        RollerDetailList.Add(rollerDetail);
                    }
                }));
            });
        }
    }
}
