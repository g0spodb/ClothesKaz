using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для PageAddClothes.xaml
    /// </summary>
    public partial class PageAddClothes : Page
    {
        public static ObservableCollection<Size> size { get; set; }
        public static ObservableCollection<TypeClothes> typeClothes { get; set; }
        public static ObservableCollection<Magazine> magazine { get; set; }
        int m { get; set; }
        int r { get; set; }
        int p { get; set; }
        public User User { get; set; }
        public Clothes clothes { get; set; }
        public PageAddClothes(User user)
        {
            User = user;
            clothes = new Clothes();
            InitializeComponent();
            size = new ObservableCollection<Size>(bd_connection.connection.Size.ToList());
            typeClothes = new ObservableCollection<TypeClothes>(bd_connection.connection.TypeClothes.ToList());
            magazine = new ObservableCollection<Magazine>(bd_connection.connection.Magazine.ToList());
            this.DataContext = this;
        }
        private void cb_type(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as TypeClothes;
            m = a.Id;
        }
        private void cb_size(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Size;
            r = a.Id;
        }
        private void cb_magazine(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Magazine;
            p = a.Id;
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            var a = new Clothes();
            a.Photo = clothes.Photo;
            a.Title = tb_Title.Text;
            a.Price = Convert.ToInt32(tb_Price.Text);
            a.Id_Type = Convert.ToInt32(m);
            a.Id_Size = Convert.ToInt32(r);
            a.Id_Magazine = Convert.ToInt32(p);
            bd_connection.connection.Clothes.Add(a);
            bd_connection.connection.SaveChanges();
            NavigationService.Navigate(new PageClothes(User));
        }
        private void PhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.jpg|*.jpg|*.png|*.png*|.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                clothes.Photo = File.ReadAllBytes(openFile.FileName);
                img_prod.Source = new BitmapImage(new Uri(openFile.FileName));

            }
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageClothes(User));
        }
    }
}
