using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace laba8
{
    /// <summary>
    /// Логика взаимодействия для MobileView.xaml
    /// </summary>
    public partial class MobileView : Window
    {
        public MobileView(MobileViewModel mobile)
        {
            InitializeComponent();

            this.DataContext = mobile;
            mobile.AnswerCall += _phoneAnswerCall;
        }
        private void _phoneAnswerCall(string dialedNumber)
        {
            CallFrom.Content = dialedNumber;
        }
    }
}
