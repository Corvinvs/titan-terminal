using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private List<TitanPage> _titanPages = new List<TitanPage>();

        public List<TitanPage> TitanPages
        {
            get
            {
                return _titanPages;
            }
        }

        private XNamespace _nameSpace;

        ObservableCollection<Unit> battleGroupUnits = new ObservableCollection<Unit>();
        public ObservableCollection<Unit> BattleGroupUnits { get { return battleGroupUnits; } }

        public BattleGroup(XDocument battleGroup)
        {
            InitializeComponent();
            _battleGroup = battleGroup;
        }

        async void UnitSelect(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem == null) return;

            var selectedUnit = unitsList.SelectedItem as Unit;
            unitsList.SelectedItem = null;

            var categories = selectedUnit.UnitElement.Element(_nameSpace + "categories");
            var q = categories.Elements().ToList();
//            if (categories.Elements().ToList().Count == 2)
//            {
                var selectedPage = _titanPages.SingleOrDefault(p => p.TitanElement == selectedUnit.UnitElement);
                // Open Titan Page
                await Navigation.PushAsync(selectedPage);
//            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ProcessingBattleGroup();
        }

        // Processing BattleGroup
        private void ProcessingBattleGroup()
        {
            // Fill list only for first page appearing
            if (_titanPages.Count == 0 )
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

                foreach (var unit in units)
                {
                    battleGroupUnits.Add(unit);
                    _titanPages.Add(new TitanPage(unit.UnitElement));
                }

                unitsList.ItemsSource = battleGroupUnits;
            }

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
