using System;
using FirstFloor.ModernUI.Presentation;
using XModule.Interfaces;
using KeepaModule.Views;

namespace KeepaModule.Services
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
                DisplayName = "KeepaModule"
            };

            linkGroup.Links.Add(new Link
            {
                DisplayName = "KeepaModule",
                Source = new Uri($"/KeepaModule;component/Views/{nameof(MainView)}.xaml", UriKind.Relative)
            });

            return linkGroup;
        }
    }
}
