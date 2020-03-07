using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TitanTerminal.Models;
using Xamarin.Forms;

namespace TitanTerminal.Pages
{
    public partial class TitanPage : ContentPage
    {
        private readonly XElement _titanElement;
        private readonly XNamespace _nameSpace;
        private readonly TitanUnit _titan;

        private string _title;

        public XElement TitanElement { get{ return _titanElement; } }
        public string TitanTitle { get{ return _title; } }
        public TitanUnit Titan { get{ return _titan; } }

        public int TitanPlasma { get { return Titan.Plasma; } }

        public TitanPage(XElement titanElement)
        {
            InitializeComponent();
            _titanElement = titanElement;
            _nameSpace = _titanElement.Name.Namespace;
            _titan = new TitanUnit();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ProcessingTitanElemen();
        }

        private void ProcessingTitanElemen()
        {
            // Initial Setup parameters
            if (string.IsNullOrWhiteSpace(_title))
            {
                _title = _titanElement.Attribute("name").Value;
                var profile = _titanElement
                    .Element(_nameSpace + "profiles")
                    .Element(_nameSpace + "profile")
                    .Element(_nameSpace + "characteristics")
                    .Elements(_nameSpace + "characteristic").ToList();

                _titan.Speed = profile
                    .SingleOrDefault(p => p.Attribute("name") != null && p.Attribute("name").Value == "Speed")?.Value;
                _titan.Command = profile
                    .SingleOrDefault(p => p.Attribute("name") != null && p.Attribute("name").Value == "Command")?.Value;
                _titan.BallisticSkill = profile
                    .SingleOrDefault(p => p.Attribute("name") != null && p.Attribute("name").Value == "Ballistic Skill")?.Value;
                _titan.WeaponSkill = profile
                    .SingleOrDefault(p => p.Attribute("name") != null && p.Attribute("name").Value == "Weapon Skill")?.Value;
                _titan.Manuever = profile
                    .SingleOrDefault(p => p.Attribute("name") != null && p.Attribute("name").Value == "Manuever")?.Value;
                _titan.ServitorClades = profile
                    .SingleOrDefault(p => p.Attribute("name") != null && p.Attribute("name").Value == "Servitor Clades")?.Value;
                _titan.Scale = profile
                    .SingleOrDefault(p => p.Attribute("name") != null && p.Attribute("name").Value == "Scale")?.Value;

                var categories = _titanElement
                    .Element(_nameSpace + "categories")
                    .Elements(_nameSpace + "category").ToList();
                if (categories.Count == 2)
                {
                    var type = categories[1].Attribute("name").Value;
                    switch (type)
                    {
                        case "WarhoundTitan":
                            _titan.Type = TitanType.Warhound;
                            break;
                        case "WarlordTitan":
                            _titan.Type = TitanType.Warlord;
                            break;
                        case "ReaverTitan":
                            _titan.Type = TitanType.Reaver;
                            break;
                    }
                }

                var structureReactorShield = _titanElement
                    .Element(_nameSpace + "selections")
                    .Elements(_nameSpace + "selection").ToList();

                var body = structureReactorShield
                    .SingleOrDefault(p => p.Attribute("name") != null && p.Attribute("name").Value == "Body");
                if (body != null)
                {
                    var bodySections = body
                    .Element(_nameSpace + "selections")
                    .Elements(_nameSpace + "selection").ToList();

                    var structure = bodySections[bodySections.Count - 1].Attribute("name").Value;
                    var start = structure.IndexOf("(") + 1;
                    var end = structure.IndexOf(")");
                    _titan.Body = System.Convert.ToInt32(structure.Substring(start, end - start));
                    if (bodySections.Count == 2)
                    {
                        var critical = bodySections[0].Attribute("name").Value;
                        _titan.BodyCritical = System.Convert.ToInt32(critical.Substring(0, 1));
                    }
                }

                var head = structureReactorShield
                    .SingleOrDefault(p => p.Attribute("name") != null && p.Attribute("name").Value == "Head");
                if (head != null)
                {
                    var headSections = head
                    .Element(_nameSpace + "selections")
                    .Elements(_nameSpace + "selection").ToList();

                    var structure = headSections[headSections.Count - 1].Attribute("name").Value;
                    var start = structure.IndexOf("(") + 1;
                    var end = structure.IndexOf(")");
                    _titan.Head = System.Convert.ToInt32(structure.Substring(start, end - start));
                    if (headSections.Count == 2)
                    {
                        var critical = headSections[0].Attribute("name").Value;
                        _titan.HeadCritical = System.Convert.ToInt32(critical.Substring(0, 1));
                    }
                }

                var legs = structureReactorShield
                    .SingleOrDefault(p => p.Attribute("name") != null && p.Attribute("name").Value == "Legs");
                if (legs != null)
                {
                    var legsSections = legs
                    .Element(_nameSpace + "selections")
                    .Elements(_nameSpace + "selection").ToList();

                    var structure = legsSections[legsSections.Count - 1].Attribute("name").Value;
                    var start = structure.IndexOf("(") + 1;
                    var end = structure.IndexOf(")");
                    _titan.Legs = System.Convert.ToInt32(structure.Substring(start, end - start));
                    if (legsSections.Count == 2)
                    {
                        var critical = legsSections[0].Attribute("name").Value;
                        _titan.LegsCritical = System.Convert.ToInt32(critical.Substring(0, 1));
                    }
                }

                var plasma = structureReactorShield
                    .SingleOrDefault(p => p.Attribute("name") != null && p.Attribute("name").Value == "Plasma Reactor");
                if (plasma != null)
                {
                    var plasmaSections = plasma
                    .Element(_nameSpace + "selections")
                    .Elements(_nameSpace + "selection").ToList();

                    var structure = plasmaSections[plasmaSections.Count - 1].Attribute("name").Value;
                    var start = structure.IndexOf("(") + 1;
                    var end = structure.IndexOf(")");
                    _titan.Plasma = System.Convert.ToInt32(structure.Substring(start, end - start));
                }

                var shield = structureReactorShield
                    .SingleOrDefault(p => p.Attribute("name") != null && p.Attribute("name").Value == "Void Shields");
                if (shield != null)
                {
                    var shieldSections = shield
                    .Element(_nameSpace + "selections")
                    .Elements(_nameSpace + "selection").ToList();

                    var structure = shieldSections[shieldSections.Count - 1].Attribute("name").Value;
                    var start = structure.IndexOf("(") + 1;
                    var end = structure.IndexOf(")");
                    _titan.Shields = structure;
                }

                PlasmaLabel.Text = Titan.Plasma.ToString();
            }

            // Bing Parameters to Page elements
            Title = $"{_title}";


        }
    }
}
