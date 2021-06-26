using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace FileSystem
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
            {
            //Получаем текужую папку приложения

            StorageFolder folder = KnownFolders.PicturesLibrary;
            IReadOnlyList<StorageFile> files = await folder.GetFilesAsync();          
            foreach  (StorageFile file in files)
                {
                filesList.Text += $"{file.Name}\n";
                var props = await file.GetBasicPropertiesAsync();
                filesList.Text += $"Дата изменения: {props.DateModified}\n";
                filesList.Text += $"Размер: {props.Size}\n\n";

                }
            }
        }
}
