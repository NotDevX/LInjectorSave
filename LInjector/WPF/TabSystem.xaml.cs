using LInjector.Classes;
using LInjector.WPF.Classes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LInjector.WPF
{
    public partial class TabSystem : UserControl
    {

        public string latestTabName { get; set; }
        monaco_api api = null;
        public TabSystem()
        {
            InitializeComponent();
            maintabs.Items.Add(CreateTab("", "Script" + " " + this.maintabs.Items.Count.ToString()));

        }

        public monaco_api current_monaco()
        {
            return maintabs.SelectedContent as monaco_api;
        }

        public void add_tab_with_text(string text, string title = null)
        {
            if (title == null)
            {
                title = "Script " + this.maintabs.Items.Count.ToString();
            }

            maintabs.Items.Add(CreateTab(text, title));
            if (ConfigHandler.monaco_minimap == true)
            {
                api.enable_autocomplete();
                api.enable_minimap();
            }
        }

        public void ChangeCurrentTabTitle(string title)
        {
            if (maintabs.SelectedItem is TabItem selectedTab)
            {
                selectedTab.Header = title;
            }
        }

        public Task<string> GetCurrentTabTitle()
        {
            if (maintabs.SelectedItem is TabItem selectedTab)
            {
                return Task.FromResult(selectedTab.Header.ToString());
            }

            return Task.FromResult(string.Empty);
        }


        public void ButtonTabs(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "AddT":
                    maintabs.Items.Add(CreateTab("", "Script" + " " + this.maintabs.Items.Count.ToString()));
                    CwDt.Cw($"Added Tab: {"Script "} {this.maintabs.Items.Count.ToString()}");
                    break;
                case "RemoveT":
                    try
                    {
                        if (maintabs.Items.Count > 1)
                        {
                            maintabs.Items.Remove(maintabs.SelectedItem);
                            CwDt.Cw("Removed Tab");
                        }
                    }
                    catch { }
                    break;
            }
        }
        public monaco_api CreateEditor(string Start) => new monaco_api(Start);

        public TabItem CreateTab(string content, string Title = "Untitled") =>
            new TabItem
            {
                Header = Title,
                Style = TryFindResource("EETABSSSSSS") as Style,
                Foreground = Brushes.White,
                FontSize = 12,
                Content = CreateEditor(content),
                IsSelected = true,
            };
    }
}
