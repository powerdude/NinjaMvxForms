using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace NinjaMvxForms.Droid.Presenters
{
    public abstract class MvxFormsSplashScreenActivity
        : MvxSplashScreenActivity
    {
        protected MvxFormsSplashScreenActivity() { }

        protected MvxFormsSplashScreenActivity(int resourceId)
            : base(resourceId) { }

        public override void InitializationComplete()
        {
            StartActivity(typeof(MvxFormsApplicationActivity));
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
        }
    }
}