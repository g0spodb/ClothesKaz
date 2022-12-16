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
    /// Логика взаимодействия для PageDress.xaml
    /// </summary>
    public partial class PageDress : Page
    {
        Clothes Clothes;
        public static ObservableCollection<Clothes> clothes { get; set; }
        public PageDress(Clothes clothes)
        {
            InitializeComponent();
            Clothes = clothes;
            var currentRecipes = KlimCloEntities.GetContext().Clothes.ToList();
            this.DataContext = Clothes;
            tb_Title.Text = clothes.Title;
            tb_Type.Text = clothes.TypeClothes.Title;
            tb_Price.Text = clothes.Price + "  р.";
            tb_Size.Text = clothes.Size.Title;
            tb_Magazine.Text = clothes.Magazine.Title;
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
