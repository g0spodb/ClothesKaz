using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClothesKaz
{
    /// <summary>
    /// Логика взаимодействия для PageAddMagazine.xaml
    /// </summary>
    public partial class PageAddMagazine : Page
    {
        public Magazine magazine { get; set; }
        public PageAddMagazine()
        {
            InitializeComponent();
            this.DataContext = this;
            magazine = new Magazine();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            var a = new Magazine();
            a.Photo = magazine.Photo;
            a.Title = tb_Title.Text;
            a.Adress = tb_Adress.Text;
            a.Login = tb_Login.Text;
            a.Description = tb_Des.Text;
            a.Password = pb_Password.Password;
            bd_connection.connection.Magazine.Add(a);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("Магазин успешно зарегистрирован " + a.Title);
            NavigationService.Navigate(new PageMagazines());
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void PhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.jpg|*.jpg|*.png|*.png*|.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                magazine.Photo = File.ReadAllBytes(openFile.FileName);
                img_prod.Source = new BitmapImage(new Uri(openFile.FileName));

            }
        }
    }
}
