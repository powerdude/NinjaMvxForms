// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the Setup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using NinjaMvxForms.Core;
using NinjaMvxForms.Forms;
using NinjaMvxForms.iOS.Presenters;
using NinjaMvxForms.WindowsPhone;
using UIKit;

namespace NinjaMvxForms.iOS
{
    /// <summary>
    ///    Defines the Setup type.
    /// </summary>
    public class Setup : MvxTouchSetup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Setup"/> class.
        /// </summary>
        /// <param name="applicationDelegate">The application delegate.</param>
        /// <param name="window">The window.</param>
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        /// <summary>
        /// Creates the app.
        /// </summary>
        /// <returns>An instance of IMvxApplication</returns>
        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        /// <summary>
        /// Create an instance of IMvxTrace
        /// </summary>
        /// <returns></returns>
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

		/// <summary>
        /// Creates the presenter.
        /// </summary>
        /// <returns></returns>
        protected override IMvxTouchViewPresenter CreatePresenter()
        {
            Xamarin.Forms.Forms.Init();

            var presenter = new MvxFormsTouchViewPresenter(new MvxFormsApp(), Window);
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }
    }
}