using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Declaration
{
    public class MasterMenu : ContentPage
    {
        public ListView ListView { get; }
        public MasterMenu()
        {
            //Icon = "hamburger.png";
            var MasterMenuItems = new List<MasterMenuItem>
            {
                new MasterMenuItem
                {
                    Title = "Start",
                    Construct = () => new HelloWorldPage()
                },
                new MasterMenuItem
                {
                    Title = "scherm2",
                    Construct = () => new HelloWorldPage()
                }
            };
            ListView = new ListView
            {
                ItemsSource = MasterMenuItems,
                ItemTemplate = new DataTemplate(() => {
                    var textCell = new TextCell();
                    textCell.SetBinding(TextCell.TextProperty, "Title");
                    return textCell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None
            };
            Title = "HR Menu";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { ListView }
            };
        }
    }

    /// <summary>
    /// simple factory for creating new pages
    /// </summary>
    internal class MasterMenuItem
    {
        public Func<Page> Construct { get; set; }
        public string Title { get; set; }
    }
}