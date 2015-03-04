// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MvxFormsWindowsPhoneViewPresenter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Controls;
using NinjaMvxForms.Core.Services;
using NinjaMvxForms.Forms;
using NinjaMvxForms.Forms.Services;
using Xamarin.Forms;

namespace NinjaMvxForms.WindowsPhone.Presenters
{
    /// <summary>
    /// Defines the MvxFormsWindowsPhoneViewPresenter type.
    /// </summary>
    public class MvxFormsWindowsPhonePagePresenter
        : MvxFormsPagePresenter
        , IMvxPhoneViewPresenter
    {
        private readonly PhoneApplicationFrame _rootFrame;

        public MvxFormsWindowsPhonePagePresenter(Application mvxFormsApp, IViewModelService viewModelService, IPageService pageService, PhoneApplicationFrame rootFrame)
            : base(mvxFormsApp, viewModelService, pageService)
        {
            _rootFrame = rootFrame;
        }

        protected override void CustomPlatformInitialization(NavigationPage mainPage)
        {
            _rootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
