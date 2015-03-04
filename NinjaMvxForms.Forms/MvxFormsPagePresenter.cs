using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using NinjaMvxForms.Core.Services;
using NinjaMvxForms.Forms.Services;
using Xamarin.Forms;

namespace NinjaMvxForms.Forms
{
    public class MvxFormsPagePresenter
        : IMvxViewPresenter
    {
        /// <summary>
        /// The view model service.
        /// </summary>
        protected readonly IViewModelService ViewModelService;

        /// <summary>
        /// The page service.
        /// </summary>
        protected readonly IPageService PageService;

        /// <summary>
        /// The MvxFormsApp instance
        /// </summary>
        public Application MvxFormsApp { get; private set; }

        public MvxFormsPagePresenter(Application mvxFormsApp, IViewModelService viewModelService, IPageService pageService)
        {
            MvxFormsApp = mvxFormsApp;
            ViewModelService = viewModelService;
            PageService = pageService;
        }

        public async void ChangePresentation(MvxPresentationHint hint)
        {
            if (!(hint is MvxClosePresentationHint)) return;

            var mainPage = MvxFormsApp.MainPage as NavigationPage;

            if (mainPage == null)
            {
                Mvx.TaggedTrace("MvxFormsPresenter:ChangePresentation()", "Shit, son! Don't know what to do");
            }
            else
            {
                // TODO - perhaps we should do more here... also async void is a boo boo
                await mainPage.PopAsync();
            }
        }

        public async void Show(MvxViewModelRequest request)
        {
            if (await TryShowPage(request)) return;

            Mvx.Error("Skipping request for {0}", request.ViewModelType.Name);
        }

        private async Task<bool> TryShowPage(MvxViewModelRequest request)
        {
            var page = PageService.GetPage(request);
            if (page == null)
                return false;

            var viewModel = ViewModelService.GetViewModel(request);

            var mainPage = MvxFormsApp.MainPage as NavigationPage;

            if (mainPage == null)
            {
                MvxFormsApp.MainPage = new NavigationPage(page);
                mainPage = (NavigationPage) MvxFormsApp.MainPage;
                CustomPlatformInitialization(mainPage);
            }
            else
            {
                await mainPage.PushAsync(page);
            }

            page.BindingContext = viewModel;
            return true;
        }

        protected virtual void CustomPlatformInitialization(NavigationPage mainPage)
        {
        }
    }
}
