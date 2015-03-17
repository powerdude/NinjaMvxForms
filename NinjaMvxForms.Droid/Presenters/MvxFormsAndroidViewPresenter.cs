using Cirrious.MvvmCross.Droid.Views;
using NinjaMvxForms.Core;
using NinjaMvxForms.Core.Presenters;
using NinjaMvxForms.Core.Services.View;
using NinjaMvxForms.Forms.Services.View;

namespace NinjaMvxForms.Droid.Presenters
{
    public class MvxFormsAndroidViewPresenter
        : MvxFormsBaseViewPresenter
        , IMvxAndroidViewPresenter
    {
        public MvxFormsAndroidViewPresenter(MvxFormsApp mvxFormsApp, IViewService viewService = null)
            : base(mvxFormsApp, viewService ?? new ViewService())
        {
        }
    }
}