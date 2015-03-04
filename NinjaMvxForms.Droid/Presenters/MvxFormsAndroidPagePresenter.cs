using Cirrious.MvvmCross.Droid.Views;
using NinjaMvxForms.Core.Services;
using NinjaMvxForms.Forms;
using NinjaMvxForms.Forms.Services;

namespace NinjaMvxForms.Droid.Presenters
{
    public class MvxFormsAndroidPagePresenter
        : MvxFormsPagePresenter
        , IMvxAndroidViewPresenter
    {
        public MvxFormsAndroidPagePresenter(MvxFormsApp mvxFormsApp, IViewModelService viewModelService, IPageService pageService)
            : base(mvxFormsApp, viewModelService, pageService)
        {
        }
    }
}