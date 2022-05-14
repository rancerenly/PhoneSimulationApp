using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Linq;

namespace laba8
{
    public class MobileViewModel
    {
        public event AnswerCallHandler AnswerCall;
        public event CallHandler Call;
        public string Number { get; set; }
        public Contact SelectedContact { get; set; } = new Contact();
        public ObservableCollection<Contact> PhoneBook { get; set; }
            = new ObservableCollection<Contact>();
        public string NumberNewCLient { get; set; }
        public string NameNewClient { get; set; }

        public ISITMobile mobileOp = new ISITMobile();
        public MobileViewModel(ISITMobile mobileOp)
        {
            mobileOp.AddPhone(this);
        }
        public delegate void AnswerCallHandler(string dialedNumber);
        public void Add() // добавить в книжку
        {
            PhoneBook.Add(new Contact
            {
                Name = NameNewClient,
                Number = NumberNewCLient
            });
        }
        public void CallThem() // позвонить
        {
            Call.Invoke(SelectedContact.Number, Number);
        }
        public void CatchCalling(string callingNumber, string dialingNumber) // прием вызова
        {
            if (dialingNumber != Number)
            {
                if (PhoneBook.Select(Contact => Contact.Number).Contains(dialingNumber))
                {
                    int x = PhoneBook.Select(Contact => Contact.Number).ToList().IndexOf(dialingNumber);
                    AnswerCall.Invoke(PhoneBook[x].ToString());
                }
                else
                    AnswerCall.Invoke("Неопределенный номер");
            }
        }
        private RelayCommand _callcommand;
        public RelayCommand CallCommand
        {
            get
            {
                return _callcommand ??
                    (_callcommand = new RelayCommand(CallThem));
            }
        }
        private RelayCommand _addcommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addcommand ??
                    (_addcommand = new RelayCommand(Add));
            }
        }
    }
}
