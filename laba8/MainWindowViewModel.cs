using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static laba8.MobileViewModel;

namespace laba8
{
    public class MainWindowViewModel
    {
        private RelayCommand _addNewCLientcommand;
        public RelayCommand AddNewClientCommand
        {
            get
            {
                return _addNewCLientcommand ??
                    (_addNewCLientcommand = new RelayCommand(AddNewClient));
            }
        }
        public string NewNumber { get; set; }
        ISITMobile mobileOp = new ISITMobile();
        private void AddNewClient()
        {
            MobileViewModel mobile = new MobileViewModel(mobileOp)
            {
               Number = NewNumber
            };
            MobileView mobileView = new MobileView(mobile);
            mobileView.Show();
        }
    }
}
