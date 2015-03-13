using Android.App;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using NinjaMvxForms.Droid.Presenters;
using Xamarin.Forms.Platform.Android;

namespace NinjaMvxForms.Droid
{
    [Activity(Label = "View for anyViewModel")]
    public class MvxFormsApplicationActivity
        : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsAndroidViewPresenter;
            if (presenter == null) return;

            LoadApplication(presenter.MvxFormsApp);
            Mvx.Resolve<IMvxAppStart>().Start();
        }
    }
}