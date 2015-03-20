using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using NinjaMvxForms.Core.Services.ViewModel;
using NinjaMvxForms.Forms;
using NinjaMvxForms.Forms.Services.View;
using Xamarin.Forms;

namespace NinjaMvxForms.Droid.Presenters
{
    public class MvxFormsAndroidViewPresenter
        : IMvxAndroidViewPresenter
    {
        public readonly XamarinFormsApp XamarinFormsApp;
        private readonly IViewService _viewService;
        private readonly IViewModelService _viewModelService;

        public MvxFormsAndroidViewPresenter(XamarinFormsApp xamarinFormsApp, IViewService viewService = null, IViewModelService viewModelService = null)
        {
            XamarinFormsApp = xamarinFormsApp;
            _viewService = viewService ?? new ViewService();
            _viewModelService = viewModelService ?? new ViewModelService();
        }

        public async void ChangePresentation(MvxPresentationHint hint)
        {
            if (!(hint is MvxClosePresentationHint)) return;

            var mainPage = XamarinFormsApp.MainPage as NavigationPage;

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
            // Get the ViewModel from the request
            var viewModel = _viewModelService.GetViewModel(request);
            if (viewModel == null)
            {
                Mvx.Error("Failed to load {0}", request.ViewModelType.Name);
                return false;
            }

            // Get the Page from the ViewModel name
            string viewName;
            var page = _viewService.GetPage(request.ViewModelType.Name, out viewName);
            if (page == null)
            {
                Mvx.Error("Failed to create a Page from {0}", viewName);
                return false;
            }

            // Get the MainPage
            var mainPage = XamarinFormsApp.MainPage as NavigationPage;

            // Set the MainPage if not yet defined (first load)
            if (mainPage == null)
            {
                XamarinFormsApp.MainPage = new NavigationPage(page);
            }
            else
            {
                // Show the Page
                await mainPage.PushAsync(page);
            }

            // Set the Page context to the corresponding ViewModel
            page.BindingContext = viewModel;
            return true;
        }
    }
}