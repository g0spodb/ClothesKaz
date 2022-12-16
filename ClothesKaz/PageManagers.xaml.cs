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
    /// Логика взаимодействия для PageManagers.xaml
    /// </summary>
    public partial class PageManagers : Page
    {
        public static ObservableCollection<User> users { get; set; }
        public PageManagers()
        {
            InitializeComponent();
            var currentManagers = KlimCloEntities.GetContext().User.Where(a => a.Id_Role == 2).ToList();
            LViewManagers.ItemsSource = currentManagers;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddManager());
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAdmin());
        }
    }
}
