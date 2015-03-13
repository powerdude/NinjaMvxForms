// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the IPageService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Cirrious.MvvmCross.ViewModels;

namespace NinjaMvxForms.Forms.Services
{
    using System;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the IPageService type.
    /// </summary>
    public interface IPageService
    {
        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <param name="viewModelType"></param>
        /// <returns>
        /// A Page.
        /// </returns>
        Page GetPage(Type viewModelType);
    }
}
