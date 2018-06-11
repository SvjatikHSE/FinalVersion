using MLG;
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

namespace Game_UI
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        DBRepository _repo;
        public RegistrationPage(DBRepository repo)
        {
            InitializeComponent();
            _repo = repo;
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User();
            if (!String.IsNullOrEmpty(NameBox.Text) && !String.IsNullOrEmpty(PasswordBox1.Password)
                && PasswordBox1.Password == PasswordBox2.Password)
            {
                if (!_repo.FindUser(NameBox.Text, PasswordBox1.Password, out newUser))
                {
                    newUser = new User();
                    newUser.Name = NameBox.Text;
                    newUser.Password = PasswordBox1.Password;
                    _repo.AddUser(newUser);
                    var packpage = new PackPage(newUser);
                    NavigationService.Navigate(packpage);
                }
                else { MessageBlock.Text = "Юзер с такими данным уже существует"; }

            }
            else { MessageBlock.Text = "Введены некорректные данные"; }
           
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }
    }
}
