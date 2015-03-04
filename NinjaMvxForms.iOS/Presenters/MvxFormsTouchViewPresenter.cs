using Cirrious.MvvmCross.Touch.Views.Presenters;
using NinjaMvxForms.Core.Services;
using NinjaMvxForms.Forms;
using NinjaMvxForms.Forms.Services;
using UIKit;
using Xamarin.Forms;

namespace NinjaMvxForms.iOS.Presenters
{
    public class MvxFormsTouchPagePresenter
        : MvxFormsPagePresenter
        , IMvxTouchViewPresenter
    {
        private readonly UIWindow _window;

        public MvxFormsTouchPagePresenter(Xamarin.Forms.Application mvxFormsApp, IViewModelService viewModelService, IPageService pageService, UIWindow window)
            : base(mvxFormsApp, viewModelService, pageService)
        {
            _window = window;
        }

        public virtual bool PresentModalViewController(UIViewController controller, bool animated)
        {
            return false;
        }

        public virtual void NativeModalViewControllerDisappearedOnItsOwn()
        {
        }

        protected override void CustomPlatformInitialization(NavigationPage mainPage)
        {
            _window.RootViewController = mainPage.CreateViewController();
        }
    }
}
