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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelManagementSystem.Pages
{
    public partial class PaymentPage : Window
    {
        public event EventHandler<PaymentDataEventArgs> PaymentDataReturned;
        string [] paymentInfo = new string[4] ;
        double tax, totalBill;



        public PaymentPage()
        {
            InitializeComponent();
        }


        public void FillTextBoxes(int roomBill, int foodBill)
        {
            tax = ((roomBill + foodBill) * 0.14);
            totalBill = roomBill + foodBill + tax;

            roomBillTxt.Text = "E£ "+ roomBill.ToString();
            foodBillTxt.Text = "E£ " + foodBill.ToString();
            taxTxt.Text = "E£ " + tax.ToString("F2");
            totalTxt.Text = "E£ " + totalBill.ToString();
        }





        public class PaymentDataEventArgs : EventArgs
        {
            public double TotalBill { get; set; }
            public string[] PaymentInfo { get; set; }

            public PaymentDataEventArgs(string[] paymentInfo, double totalBill)
            {
                PaymentInfo = paymentInfo;
                TotalBill = totalBill;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            paymentInfo[0] = PaymentType.Text;
            paymentInfo[1] = cardNum.Text;
            paymentInfo[2] = $"{expMonth.Text}/{expYear.Text}";
            paymentInfo[3] = cvc.Text;

            PaymentDataReturned?.Invoke(this, new PaymentDataEventArgs(paymentInfo, totalBill));
            this.Close();
        }

    }
}
