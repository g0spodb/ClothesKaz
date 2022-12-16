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
    /// Логика взаимодействия для PageMagazine.xaml
    /// </summary>
    public partial class PageMagazine : Page
    {
        Magazine Magazine;
        public static ObservableCollection<Magazine> magazine { get; set; }
        public PageMagazine(Magazine magazine)
        {
            InitializeComponent();
            Magazine = magazine;
            var currentMagazines = KlimCloEntities.GetContext().Magazine.ToList();
            this.DataContext = Magazine;
            tb_Title.Text = magazine.Title;
            tb_Adress.Text = magazine.Adress;
            tb_Des.Text = magazine.Description;
            tb_Login.Text = magazine.Login;
            tb_Password.Text = magazine.Password;
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
