using System;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Presentation;
using prism7.Themes;
using prism7.Views;

namespace prism7
{
    public partial class Shell : ModernWindow
    {
        public Shell()
        {
            InitializeComponent();
            AppearanceManager.Current.ThemeSource = new Uri(ThemesPath.Light, UriKind.Relative);
            
        }

        public void AddLinkGroups(LinkGroupCollection linkGroupCollection)
        {
            CreateMenuLinkGroup();

            foreach (LinkGroup linkGroup in linkGroupCollection)
            {
                this.MenuLinkGroups.Add(linkGroup);
            }
        }

        private void CreateMenuLinkGroup()
        {
            this.MenuLinkGroups.Clear();

            LinkGroup linkGroup = new LinkGroup
            {
                DisplayName = "Settings",
                GroupKey = "settings"
            };

            linkGroup.Links.Add(new Link
            {
                DisplayName = "Settings options",
                Source = GetUri(typeof(SettingsView))
            });

            this.MenuLinkGroups.Add(linkGroup);

            linkGroup = new LinkGroup
            {
                DisplayName = "Aperature"
            };

            linkGroup.Links.Add(new Link
            {
                DisplayName = "Novi",
                Source = GetUri(typeof(IntroductionView))
            });

            linkGroup.Links.Add(new Link
            {
                DisplayName = "Active Requests",
                Source = GetUri(typeof(MUIView))
            });

            linkGroup.Links.Add(new Link
            {
                DisplayName = "Edit Requests",
                Source = GetUri(typeof(DataGrid))
            });

            linkGroup.Links.Add(new Link
            {
                DisplayName = "About",
                Source = GetUri(typeof(LoremIpsumView))
            });

            this.MenuLinkGroups.Add(linkGroup);
        }

        private Uri GetUri(Type viewType)
        {
            return new Uri($"/Views/{viewType.Name}.xaml", UriKind.Relative);
        }
    }
}