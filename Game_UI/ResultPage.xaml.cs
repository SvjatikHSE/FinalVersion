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
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        Session _session;
        public ResultPage(Session session)
        {
            _session = session;
            PleaseWork.Content= "Вы правильно ответили на " + session.Score + " вопросов из 24";
            // Result.Text = "Вы правильно ответили на "+ session.Score +" вопросов из 24";
            UILogic.CreateSession(session.User, session.Package, session.Score);
            InitializeComponent();
        }

        private void PackButton_Click(object sender, RoutedEventArgs e)
        {
            var packpage = new PackPage(_session.User);
            NavigationService.Navigate(packpage);

        }
    }
}
