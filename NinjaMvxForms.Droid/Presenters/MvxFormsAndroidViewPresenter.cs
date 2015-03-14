using Cirrious.MvvmCross.Droid.Views;
using NinjaMvxForms.Forms;
using NinjaMvxForms.Forms.Presenters;

namespace NinjaMvxForms.Droid.Presenters
{
    public class MvxFormsAndroidViewPresenter
        : MvxFormsBaseViewPresenter
        , IMvxAndroidViewPresenter
    {
        public MvxFormsAndroidViewPresenter(MvxFormsApp mvxFormsApp, string viewSuffix = "View")
            : base(mvxFormsApp, viewSuffix)
        {
        }
    }
}