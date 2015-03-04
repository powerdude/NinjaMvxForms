// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the IViewModelService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NinjaMvxForms.Core.Services
{
    using Cirrious.MvvmCross.ViewModels;

    /// <summary>
    ///  Defines the IViewModelService type.
    /// </summary>
    public interface IViewModelService
    {
        /// <summary>
        /// Load the view model.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The View Model.</returns>
        IMvxViewModel GetViewModel(MvxViewModelRequest request);
    }
}
