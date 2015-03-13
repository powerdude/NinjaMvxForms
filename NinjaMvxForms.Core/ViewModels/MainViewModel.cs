// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MainViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using NinjaMvxForms.Core.Services;

namespace NinjaMvxForms.Core.ViewModels
{
    /// <summary>
    /// Define the MainViewModel type.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private IViewModelService _viewModelService;

        public MainViewModel(IViewModelService viewModelService)
        {
            _viewModelService = viewModelService;
        }

        /// <summary>
        /// The sample text.
        /// </summary>
        private string sampleText = "Hello from the Ninja Coder!";

        /// <summary>
        /// Gets or sets the sample text.
        /// </summary>
        public string SampleText
        {
            get { return this.sampleText; }
            set { this.SetProperty(ref this.sampleText, value); }
        }
    }
}
