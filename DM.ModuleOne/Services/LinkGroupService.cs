using System;
using FirstFloor.ModernUI.Presentation;
using ModuleOne.Views;
using XModule.Interfaces;

namespace ModuleOne.Services
{
    /// <summary>
    /// Creates a LinkGroup
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// This is the entry point for the option menu.
    /// </remarks>
    public class LinkGroupService : ILinkGroupService
    {
        public LinkGroup GetLinkGroup()
        {
            LinkGroup linkGroup = new LinkGroup
            {
                DisplayName = "Module One"
            };

            linkGroup.Links.Add(new Link
            {
                DisplayName = "Module One",
                Source = new Uri($"/ModuleOne;component/Views/{nameof(MainView)}.xaml", UriKind.Relative)
            });

            return linkGroup;
        }
    }
}
