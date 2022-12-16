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
    /// Логика взаимодействия для PageMagazines.xaml
    /// </summary>
    public partial class PageMagazines : Page
    {
        public static ObservableCollection<Magazine> magazines { get; set; }
        public PageMagazines()
        {
            InitializeComponent();
            var currentRecipes = KlimCloEntities.GetContext().Magazine.ToList();
            Magazines.ItemsSource = currentRecipes;
        }
        private void LViewMagazines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var n = (sender as ListView).SelectedItem as Magazine;
            NavigationService.Navigate(new PageMagazine(n));
        }

        private void NewMagazine(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddMagazine());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAdmin());
        }
    }
}
