using System;
using FirstFloor.ModernUI.Presentation;
using XModule.Interfaces;
using NtfsModule.Views;

namespace NtfsModule.Services
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
                DisplayName = "Ntfs"
            };

            linkGroup.Links.Add(new Link
            {
                DisplayName = "Ntfs",
                Source = new Uri($"/NtfsModule;component/Views/{nameof(MainView)}.xaml", UriKind.Relative)
            });

            return linkGroup;
        }
    }
}
