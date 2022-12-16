using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private void RegClick(object sender, RoutedEventArgs e)
        {
            var a = new User();
            a.FullName = tb_FullName.Text;
            a.Login = tb_Login.Text;
            a.Password = pb_Password.Password;
            a.Id_Role = 1;
            bd_connection.connection.User.Add(a);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрированы " + a.FullName);
            NavigationService.GoBack();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
