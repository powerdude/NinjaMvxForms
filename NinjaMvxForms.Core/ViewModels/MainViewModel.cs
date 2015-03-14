// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MainViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NinjaMvxForms.Core.ViewModels
{
    /// <summary>
    /// Define the MainViewModel type.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// The sample text.
        /// </summary>
        private string _sampleText = "Hello from the Ninja Coder!";

        /// <summary>
        /// Gets or sets the sample text.
        /// </summary>
        public string SampleText
        {
            get { return _sampleText; }
            set { SetProperty(ref _sampleText, value); }
        }
    }
}
