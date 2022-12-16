using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для PageClothes.xaml
    /// </summary>
    public partial class PageClothes : Page
    {
        public static ObservableCollection<Magazine> magazine { get; set; }
        int r { get; set; }
        User User { get; set; }
        public static ObservableCollection<Clothes> clothes { get; set; }
        public PageClothes(User user)
        {
            InitializeComponent();
            User = user;
            magazine = new ObservableCollection<Magazine>(bd_connection.connection.Magazine.ToList());
            var currentRecipes = KlimCloEntities.GetContext().Clothes.ToList();
            this.DataContext = this;
            LViewClothes.ItemsSource = currentRecipes;
            if (user.Id_Role == 2)
            {
                Add.Visibility = Visibility.Visible;
            }
            if (user.Id_Role == 1)
            {
                cbMagazine.Visibility = Visibility.Visible;
            }
        }
        private void cb_magazine(object sender, SelectionChangedEventArgs e)
        {
            var g = (sender as ComboBox).SelectedItem as Magazine;
            r = g.Id;
            var currentRecipes = KlimCloEntities.GetContext().Clothes.Where(a => a.Id_Magazine == r).ToList();
            LViewClothes.ItemsSource = currentRecipes;
            this.DataContext = this;
        }

        private void AccountClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAccount(User));
        }

        private void LViewClothes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var n = (sender as ListView).SelectedItem as Clothes;
            NavigationService.Navigate(new PageDress(n));
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAutho());
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddClothes(User));
        }
    }
}
