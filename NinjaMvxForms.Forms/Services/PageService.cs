// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the PageService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Xamarin.Forms;

namespace NinjaMvxForms.Forms.Services
{
    /// <summary>
    ///  Defines the PageService type.
    /// </summary>
    public class PageService : IPageService
    {
        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// A Page.
        /// </returns>
        public Page GetPage(MvxViewModelRequest request)
        {
            var viewModelName = request.ViewModelType.Name;
            var viewName = viewModelName.Replace("ViewModel", "View");
            var view = typeof(PageService).GetTypeInfo().Assembly.DefinedTypes.FirstOrDefault(x => x.Name == viewName);
            if (view == null)
            {
                Mvx.Trace("View not found for {0}", viewName);
                return null;
            }

            var page = Activator.CreateInstance(view.AsType()) as Page;
            if (page == null)
            {
                Mvx.Error("Failed to create ContentPage {0}", viewName);
            }

            return page;
        }
    }
}
