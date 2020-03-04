using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Xamarin.Forms;

namespace TitanTerminal.Pages
{
    public partial class TitanPage : ContentPage
    {
        private readonly XElement _titanElement;
        private readonly XNamespace _nameSpace;

        public TitanPage(XElement titanElement)
        {
            InitializeComponent();
            _titanElement = titanElement;
            _nameSpace = _titanElement.Name.Namespace;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ProcessingTitanElemen();
        }

        private void ProcessingTitanElemen()
        {
            var title = _titanElement.Attribute("name");
            Title = $"{title}";


        }
    }
}
