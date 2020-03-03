using System;
using TitanTerminal.Contracts;
using TitanTerminal.Models;
using Xamarin.Forms;

namespace TitanTerminal
{
    public class Terminal : ContentPage, ITerminal
    {
        private Grid _grid;

        public Terminal(string name, ITitan titan)
        {
            Init(name, titan);
        }

        public void Init(string name, ITitan titan)
        {
            _grid = new Grid
            {
                ColumnSpacing = 1,
                RowSpacing = 1,
                //BackgroundColor = Color.Black,
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            var totalColumns = _grid.ColumnDefinitions.Count;

            // Set Header Row
            var header = new Label
            {
                Text = "Titan Terminal",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Black
            };
            _grid.Children.Add(header, 0, 0);
            Grid.SetColumnSpan(header, totalColumns);
            /*
                        // Set Orders and NameAndType row
                        var orders = GetOrders();
                        _grid.Children.Add(orders, 0, 1);
                        Grid.SetColumnSpan(orders, 4);
                        Grid.SetRowSpan(orders, 3);

                        var nameAndType = GetNameAndType(name, titan);
                        _grid.Children.Add(nameAndType, 4, 1);
                        Grid.SetColumnSpan(nameAndType, totalColumns - 4);
                        Grid.SetRowSpan(nameAndType, 3);
            */
            _grid.Children.Add(new Label { Text = "1.1"}, 0, 1);
            _grid.Children.Add(new Label { Text = "1.2" }, 1, 1);
            _grid.Children.Add(new Label { Text = "1.3" }, 2, 1);
            _grid.Children.Add(new Label { Text = "1.4" }, 3, 1);
            _grid.Children.Add(new Label { Text = "1.5" }, 4, 1);
            _grid.Children.Add(new Label { Text = "1.6" }, 5, 1);
            _grid.Children.Add(new Label { Text = "1.7" }, 6, 1);
            _grid.Children.Add(new Label { Text = "1.8" }, 7, 1);
            _grid.Children.Add(new Label { Text = "1.9" }, 8, 1);
            _grid.Children.Add(new Label { Text = "1.10" }, 9, 1);
            _grid.Children.Add(new Label { Text = "1.11" }, 10, 1);
            _grid.Children.Add(new Label { Text = "1.12" }, 11, 1);
            _grid.Children.Add(new Label { Text = "1.13" }, 12, 1);
            _grid.Children.Add(new Label { Text = "1.14" }, 13, 1);
            _grid.Children.Add(new Label { Text = "1.15" }, 14, 1);
            _grid.Children.Add(new Label { Text = "1.16" }, 15, 1);
            _grid.Children.Add(new Label { Text = "1.17" }, 16, 1);
            _grid.Children.Add(new Label { Text = "1.18" }, 17, 1);
            _grid.Children.Add(new Label { Text = "1.19" }, 18, 1);
            _grid.Children.Add(new Label { Text = "1.20" }, 19, 1);
            _grid.Children.Add(new Label { Text = "1.21" }, 20, 1);

            Content = new StackLayout
            {
                Children = {
                    _grid
                }
            };
        }

        private Label GetOrders()
        {
            return new Label
            {
                Text = "\n ORDERS \n",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Silver
            };
        }

        private StackLayout GetNameAndType(string name, ITitan titan)
        {
            return new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = $" {titan.Type.ToString().ToUpper()} TITAN \n {name} \n SCALE: {titan.Scale} ({titan.ScaleDescription}) {titan.Cost} + WEAPONS",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        BackgroundColor = Color.DarkGray,
                        
                    },
/*                    new Label
                    {
                        Text = $"{name}",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        BackgroundColor = Color.DarkGray
                    },
                    new Label
                    {
                        Text = $"SCALE: {titan.Scale} ({titan.ScaleDescription})\t{titan.Cost} + WEAPONS",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        BackgroundColor = Color.DarkGray
                    }*/
                }
            };
        }
    }
}

