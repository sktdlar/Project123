using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Project123.Components.Controls
{
    public static  class TabControlMechanism
    {
        public static void AddTab(Page page, String Title)
        {
            var tabItem = new TabItem()
            {
                Header = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Children =
                    {
                new TextBlock { Text = Title, FontSize = 24,  },
                new Button
                {
                    Content = "✖",
                    Background = Brushes.Transparent,
                    BorderBrush = Brushes.Transparent,
                    Padding = new Thickness(5, 0, 0, 0),
                    Cursor = Cursors.Hand
                }
                    }
                },
                Content = new Frame()
                {
                    Content = page
                }

            };
            var closeButton = (Button)((StackPanel)tabItem.Header).Children[1];

            closeButton.Click += (sender, e) =>
            {
                var tabControl = App.mainWindow.tabControl;
                tabControl.Items.Remove(tabItem);
            };
            if(App.mainWindow.tabControl.Items.Count >= 8)
            {

            }
            else
            {
                App.mainWindow.tabControl.Items.Add(tabItem);

            }
        }
        public static void RemoveTab(Page page)
        {
            App.mainWindow.tabControl.Items.Remove(page);
        }
    }
}
