﻿using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using TitanTerminal.Contracts;
using Xamarin.Forms;

namespace TitanTerminal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await UpdateFileList();
        }

        async void FileSelect(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem == null) return;
            // получаем выделенный элемент
            string filename = (string)args.SelectedItem;
            /*
            // загружем текст в текстовое поле
            textEditor.Text = await DependencyService.Get<IFileHelper>().LoadTextAsync((string)args.SelectedItem);
            // устанавливаем название файла
            fileNameEntry.Text = filename;
            */

            // Load file content
            var battleGroupContent = await DependencyService.Get<IFileHelper>().LoadTextAsync((string)args.SelectedItem);
            var battleGroupXml = XDocument.Parse(battleGroupContent);

            // снимаем выделение
            filesList.SelectedItem = null;

            // Open BattleGroup Page


        }

        // обновление списка файлов
        async Task UpdateFileList()
        {
            // получаем все файлы
            filesList.ItemsSource = await DependencyService.Get<IFileHelper>().GetFilesAsync();
            // снимаем выделение
            filesList.SelectedItem = null;
        }
    }
}