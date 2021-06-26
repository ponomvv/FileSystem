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
    public sealed partial class MainPage: Page
        {
        public MainPage()
            {
            this.InitializeComponent();
            }

        private async void saveButton_Click(object sender, RoutedEventArgs e)
            {
            string text = myTextBox.Text;
            //Получаем локальную папку
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            //Создаем файл hello.txt
            StorageFile helloFile = await localFolder.CreateFileAsync("hello.txt", CreationCollisionOption.ReplaceExisting);
            //Запись в файл
            await FileIO.WriteTextAsync(helloFile, text);
            await new Windows.UI.Popups.MessageDialog("Файл создан и сохранен").ShowAsync();
            }

        private async void openButton_Click(object sender, RoutedEventArgs e)
            {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            //получаем файл
            StorageFile helloFile = await localFolder.GetFileAsync("hello.txt");
            //читаем файл
            string text = await FileIO.ReadTextAsync(helloFile);
            myTextBox.Text = text;
            await new Windows.UI.Popups.MessageDialog("Файл открыт").ShowAsync();
            }
        }
}
