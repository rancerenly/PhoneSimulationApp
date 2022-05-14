using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public delegate void CallHandler(string callingNumber, string dialedNumber);
    public class ISITMobile
    {
        public List<MobileViewModel> Phones { get; }
            = new List<MobileViewModel>();
        public void CatchCalling(string callingNumber, string dialedNumber)
        {
            Call.Invoke(callingNumber, dialedNumber);
        }
        public void AddPhone(MobileViewModel phone)
        {
            Phones.Add(phone);

            phone.Call += CatchCalling;
            this.Call += phone.CatchCalling;
        }
        public event CallHandler Call;

    }
}
