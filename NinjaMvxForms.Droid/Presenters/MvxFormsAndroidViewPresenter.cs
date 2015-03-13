using Cirrious.MvvmCross.Droid.Views;
using NinjaMvxForms.Core.Services;
using NinjaMvxForms.Forms;
using NinjaMvxForms.Forms.Presenters;
using NinjaMvxForms.Forms.Services;

namespace NinjaMvxForms.Droid.Presenters
{
    public class MvxFormsAndroidViewPresenter
        : MvxFormsBaseViewPresenter
        , IMvxAndroidViewPresenter
    {
        public MvxFormsAndroidViewPresenter(MvxFormsApp mvxFormsApp, IViewModelService viewModelSuffixService = null, IPageService pageService = null)
            : base(mvxFormsApp, viewModelSuffixService, pageService)
        {
        }
    }
}