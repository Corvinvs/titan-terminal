using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using TitanTerminal.Contracts;
using Xamarin.Forms;

namespace TitanTerminal.Pages
{
    public partial class BattleGroupList : ContentPage
    {
        public BattleGroupList()
        {
            InitializeComponent();
            Title = "AVAILABLE BATTLEGROUPS";
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await UpdateFileList();
        }

        async void FileSelect(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem == null) return;

            // Load file content of selected file
            var battleGroupContent = await DependencyService.Get<IFileHelper>().LoadTextAsync((string)args.SelectedItem);
            var battleGroupXml = XDocument.Parse(battleGroupContent);

            // снимаем выделение
            filesList.SelectedItem = null;

            // Open BattleGroup Page
            await Navigation.PushAsync(new BattleGroup(battleGroupXml));

        }

        // обновление списка файлов
        async Task UpdateFileList()
        {
            var q = await DependencyService.Get<IFileHelper>().GetFilesAsync();
            // получаем все файлы
            filesList.ItemsSource = await DependencyService.Get<IFileHelper>().GetFilesAsync();
            // снимаем выделение
            filesList.SelectedItem = null;
        }
    }
}
