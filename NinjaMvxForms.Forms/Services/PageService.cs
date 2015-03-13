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
        private readonly string _viewSuffix;

        public PageService(string viewSuffix = "View")
        {
            _viewSuffix = viewSuffix;
        }

        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <returns>
        /// A Page.
        /// </returns>
        public Page GetPage(Type viewModelType)
        {
            var viewName = viewModelType.Name.Replace("ViewModel", _viewSuffix);

            var assembly = typeof(PageService).GetTypeInfo().Assembly;

            var typeInfo = assembly.DefinedTypes.FirstOrDefault(x => x.Name == viewName);

            if (typeInfo == null) return null;

            var type = typeInfo.AsType();

            if (type == null)
            {
                Mvx.Error("Failed to create Page {0}", viewName);
                return null;
            }

            return Activator.CreateInstance(type) as Page;
        }
    }
}
