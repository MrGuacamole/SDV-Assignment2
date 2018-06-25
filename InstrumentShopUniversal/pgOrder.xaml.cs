using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace InstrumentShopUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgOrder : Page
    {
        public pgOrder()
        {
            this.InitializeComponent();
        }

        private clsAllInstrument _Instrument;
        private clsOrders _Order = new clsOrders();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _Instrument = e.Parameter as clsAllInstrument;
            SetDetails(_Instrument);
        }

        private void SetDetails(clsAllInstrument prInstrument)
        {
            txbInstrumentName.Text = "Instrument Name: " + prInstrument.InstrumentName;
            txbPrice.Text = "Price $: " + Convert.ToString(prInstrument.InstrumentPrice);
            txbType.Text = "Type: " + prInstrument.Type;
            txbQuantity.Text = "Quantity:" + Convert.ToString(prInstrument.Quantity);
        }

        private async void btnConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            PushData(_Instrument);
           if (_Instrument.Quantity >= _Order.Quantity & _Order.Quantity > 0)
            {
                txbMessage.Text = (await clsServiceClient.InsertOrderAsync(_Order));
                if (txbMessage.Text == "\"Your order has been placed\"")
                {
                    int lcNewQuantity = _Instrument.Quantity - _Order.Quantity;
                    _Instrument.Quantity = lcNewQuantity;
                    await clsServiceClient.UpdateInstrumentAsync(_Instrument);
                    Frame.Navigate(typeof(pgMain), "Your order has been placed");
                }
            }
            else
            {
                txbMessage.Text = "invalid order quantity";
            }

        }

        private void PushData(clsAllInstrument prInstrument)
        {
            try
            {
                _Order.InstrumentID = prInstrument.InstrumentID;
                _Order.OrderDate = (Convert.ToString(DateTime.Today)).Substring(0, 10);
                _Order.Quantity = Convert.ToInt16(txtOrderQuantity.Text);
                _Order.OrderPrice = (_Order.Quantity * prInstrument.InstrumentPrice);
                _Order.CustomerCity = txtCustomerCity.Text;
                _Order.CustomerName = txtCustomerName.Text;
            }
                
           catch (Exception ex)
            {
                txbMessage.Text = ex.Message;
                return;
            }
        
            

        }
    }
}
