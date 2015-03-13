using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using NinjaMvxForms.Core.Services;
using NinjaMvxForms.Forms.Services;
using Xamarin.Forms;

namespace NinjaMvxForms.Forms.Presenters
{
    public abstract class MvxFormsBaseViewPresenter
        : IMvxViewPresenter
    {
        private readonly IViewModelService _viewModelService;
        private readonly IPageService _pageService;
        public readonly Application MvxFormsApp;

        protected MvxFormsBaseViewPresenter(Application mvxFormsApp, IViewModelService viewModelSuffixService = null, IPageService pageService = null)
        {
            MvxFormsApp = mvxFormsApp;
            _viewModelService = viewModelSuffixService ?? new ViewModelService();
            _pageService = pageService ?? new PageService();
        }

        public async void ChangePresentation(MvxPresentationHint hint)
        {
            if (!(hint is MvxClosePresentationHint)) return;

            var mainPage = MvxFormsApp.MainPage as NavigationPage;

            if (mainPage == null)
            {
                Mvx.TaggedTrace("MvxFormsViewPresenter:ChangePresentation()", "Shit, son! Don't know what to do");
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
            var page = _pageService.GetPage(request.ViewModelType);
            if (page == null) return false;

            var viewModel = _viewModelService.GetViewModel(request);
            if (viewModel == null) return false;

            var mainPage = MvxFormsApp.MainPage as NavigationPage;

            if (mainPage == null)
            {
                MvxFormsApp.MainPage = new NavigationPage(page);
                mainPage = (NavigationPage)MvxFormsApp.MainPage;
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
