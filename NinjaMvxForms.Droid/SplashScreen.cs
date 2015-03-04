// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the SplashScreen type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Android.App;
using Android.Content.PM;
using NinjaMvxForms.Droid.Presenters;

namespace NinjaMvxForms.Droid
{
    /// <summary> 
    /// Defines the SplashScreen type.
    /// </summary>
    [Activity(
        Label = "FormsPresenters.Sample.Droid"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxFormsSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}