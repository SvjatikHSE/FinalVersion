using Game_UI;
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

namespace Game_of_brains_UI
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page

    {
        private DBRepository repository;
        private User user;
        public MainPage()
        {
            InitializeComponent();
            repository = new DBRepository();
            user = new User();
        }


        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            var regpage = new RegistrationPage(repository);
            NavigationService.Navigate(regpage);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (repository.FindUser(TeamName.Text, Passwordbox.Password, out user))
            {
                var packPage = new PackPage(user);
                NavigationService.Navigate(packPage);
            }
            else {
                MessageBlock.Text = "Введены некорректные данные";
                Passwordbox.Password = "";
            }
        }

        private void TeamName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                Passwordbox.Focus();
            }
        }

        private void Passwordbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (TeamName.Text != "")
                {
                    if (repository.FindUser(TeamName.Text, Passwordbox.Password, out user))
                    {
                        var packPage = new PackPage(user);
                        NavigationService.Navigate(packPage);
                    }
                    else
                    {
                        MessageBlock.Text = "Введены некорректные данные";
                        Passwordbox.Password = "";
                    }
                }
                else
                {
                    TeamName.Focus();
                    MessageBlock.Text = "Не заполнено поле названия команды";
                }
            }
        }
    }
}
