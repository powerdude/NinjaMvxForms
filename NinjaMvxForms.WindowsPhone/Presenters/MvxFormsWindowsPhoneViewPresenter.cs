// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MvxFormsWindowsPhoneViewPresenter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Controls;
using NinjaMvxForms.Core.Services;
using NinjaMvxForms.Forms.Presenters;
using NinjaMvxForms.Forms.Services;
using Xamarin.Forms;

namespace NinjaMvxForms.WindowsPhone.Presenters
{
    /// <summary>
    /// Defines the MvxFormsWindowsPhoneViewPresenter type.
    /// </summary>
    public class MvxFormsWindowsPhoneViewPresenter
        : MvxFormsBaseViewPresenter
        , IMvxPhoneViewPresenter
    {
        private readonly PhoneApplicationFrame _rootFrame;

        public MvxFormsWindowsPhoneViewPresenter(Application mvxFormsApp, PhoneApplicationFrame rootFrame, IViewModelService viewModelSuffixService = null, IPageService pageService = null)
            : base(mvxFormsApp, viewModelSuffixService, pageService)
        {
            _rootFrame = rootFrame;
        }

        protected override void CustomPlatformInitialization(NavigationPage mainPage)
        {
            _rootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
