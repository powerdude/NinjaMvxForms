using Cirrious.CrossCore;
using Cirrious.MvvmCross.Views;
using NinjaMvxForms.WindowsPhone.Presenters;
using Xamarin.Forms.Platform.WinPhone;

namespace NinjaMvxForms.WindowsPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsWindowsPhoneViewPresenter;
            if (presenter == null) return;

            LoadApplication(presenter.MvxFormsApp);
        }
    }
}