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
    public sealed partial class pgInstrument : Page
    {
        public pgInstrument()
        {
            this.InitializeComponent();

            _InstrumentsContent = new Dictionary<string, Delegate>
            {
                {"New", new LoadInstrumentControlDelegate(RunNew)},
                {"Used", new LoadInstrumentControlDelegate(RunUsed)}
            };
        }

        private clsAllInstrument _Instrument;

        private void updatePage(clsAllInstrument prInstrument)
        {
           
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                dispatchInstrumentContent(e.Parameter as clsAllInstrument);
            }
            
        }

        private void RunNew(clsAllInstrument prInstrument)
        {
            ctcInstrumentSpecs.Content = new ucNewInstrument();
        }

        private void RunUsed(clsAllInstrument prInstrument)
        {
            ctcInstrumentSpecs.Content = new ucUsedInstrument();
        }

        private void SetDetails(clsAllInstrument prInstrument)
        {
            _Instrument = prInstrument;
            txbInstrumentName.Text = "Instrument Name: " + prInstrument.InstrumentName;
            txbBrand.Text = "Instrument Brand: " + prInstrument.Brand;
            txbDescription.Text = "Instrument Description: " + prInstrument.Description;
            txbType.Text = "Instrument Type: " + prInstrument.Type;
            txbPrice.Text = "Instrument Price: " + Convert.ToString(prInstrument.InstrumentPrice);
            txbQuantity.Text = "Items in Stock: " + Convert.ToString(prInstrument.Quantity);

            (ctcInstrumentSpecs.Content as IInstrumentControl).UpdateControl(prInstrument);
        }

        private delegate void LoadInstrumentControlDelegate(clsAllInstrument prInstrument);
        private Dictionary<string, Delegate> _InstrumentsContent;
        private void dispatchInstrumentContent(clsAllInstrument prInstrument)
        {
            _InstrumentsContent[prInstrument.Type].DynamicInvoke(prInstrument);
            SetDetails(prInstrument);
        }

        private void txbInstrumentName_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgOrder), _Instrument);
        }
    }
}
