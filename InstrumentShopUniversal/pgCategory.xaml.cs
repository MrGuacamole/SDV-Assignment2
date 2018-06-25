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
    public sealed partial class pgCategory : Page
    {
        public pgCategory()
        {
            this.InitializeComponent();
        }

        private static Dictionary<string, pgCategory> _CategoryFormList = new Dictionary<string, pgCategory>();
        private clsCategory _Category;

        //public static void Run(string prCategoryName)
        //{
        //    pgCategory lcCategoryForm;
        //    if (string.IsNullOrEmpty(prCategoryName) ||
        //    !_CategoryFormList.TryGetValue(prCategoryName, out lcCategoryForm))
        //    {
        //        lcCategoryForm = new pgCategory();
        //        if (string.IsNullOrEmpty(prCategoryName))
        //        {
        //            lcCategoryForm.SetDetails(new clsCategory());
        //            //lcCategoryForm.UpdateDisplay(prCategoryName);
        //        }
        //        else
        //        {
        //            _CategoryFormList.Add(prCategoryName, lcCategoryForm);
        //            lcCategoryForm.refreshFormFromDBAsync(prCategoryName);
        //            Frame.Navigate(typeof(pgCategory), lstInstruments.SelectedItem);
        //            // lcCategoryForm.UpdateDisplay(prCategoryName);
        //        }
        //    }
        //    else
        //    {
        //        lcCategoryForm.Show();
        //        lcCategoryForm.Activate();
        //    }
        //}

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                string lcCategoryName = e.Parameter.ToString();
                refreshFormFromDBAsync(lcCategoryName);                
            }
            else // no parameter -> new artist!
                _Category = new clsCategory();
        }
        private async void UpdateDisplay(clsCategory prCategory)
        {
            lstInstruments.ItemsSource = null;
            if (prCategory.InstrumentList != null)
                lstInstruments.ItemsSource = prCategory.InstrumentList;
        }

        private async void refreshFormFromDBAsync(string prCategoryName)
        {
            SetDetails(await clsServiceClient.GetCategoryInstrumentsAsync(prCategoryName));
        }

        private void SetDetails(clsCategory prCategoryName)
        {
            _Category = prCategoryName;

            UpdateDisplay(_Category);
            lblCategoryName.Text = _Category.Name;
            lblCategoryDescription.Text = _Category.Description;

            //txtName.Enabled = string.IsNullOrEmpty(_Category.Name); ;
            //updateForm();
            //Show();
        }



        private void pushData()
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            //Hide();
        }

        private void lstInstruments_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
           
            Frame.Navigate(typeof(pgInstrument), lstInstruments.SelectedItem);
        }
    }
}
