using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using TitanTerminal.Models;
using Xamarin.Forms;

namespace TitanTerminal.Pages
{
    public partial class BattleGroup : ContentPage
    {
        private readonly XDocument _battleGroup;

        private XNamespace _nameSpace;

        public BattleGroup(XDocument battleGroup)
        {
            InitializeComponent();
            _battleGroup = battleGroup;
        }

        async void UnitSelect(object sender, SelectedItemChangedEventArgs args)
        {

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ProcessingBattleGroup();
        }

        // Processing BattleGroup
        private void ProcessingBattleGroup()
        {
            var root = _battleGroup.Root;
            var title = root.Attribute("name").Value;
            _nameSpace = root.Name.Namespace;
            var costElement = root.Element(_nameSpace + "costs").Element(_nameSpace + "cost");
            var forceElement = root
                .Element(_nameSpace + "forces")
                .Element(_nameSpace + "force")
                .Element(_nameSpace + "selections")
                .Elements();

            Title = $"{title}{costElement.Attribute("name").Value} {costElement.Attribute("value").Value}";
            var units = GetUnitsList(forceElement);

            unitsList.ItemsSource = units.Select(u => u.Name);
        }

        private IEnumerable<Unit> GetUnitsList(IEnumerable<XElement> forces)
        {
            var result = new List<Unit>();

            foreach(var force in forces)
            {
                var categories = force.Element(_nameSpace + "categories").Elements(_nameSpace + "category").ToList();

                // Build list of maniple's units
                if (categories.Count == 1 && categories.FirstOrDefault()?.Attribute("name").Value == "Maniple")
                {
                    result = new List<Unit>(GetUnitsList(force.Element(_nameSpace + "selections").Elements(_nameSpace + "selection")));
                }
                else
                {
                    if (force.Attribute("name").Value != "Titan Legion")
                    {
                        var cost = force
                            .Element(_nameSpace + "costs")
                            .Elements(_nameSpace + "cost")
                                .SingleOrDefault(e => e.Attribute("name").Value == " Points")?.Attribute("value").Value;
                        var name = force.Attribute("name").Value;

                        result.Add(new Unit
                        {
                            Name = name,
                            Cost = (int)System.Convert.ToDecimal(cost),
                            UnitElement = force
                        });
                    }
                }
            }

            return result;
        }

    }
}
