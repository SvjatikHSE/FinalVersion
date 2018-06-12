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
    /// Логика взаимодействия для QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        public QuestionPage(Package pack)
        {
            InitializeComponent();
            PackNameLabel.Content = pack.Name;
            QuestList.ItemsSource = pack.Questions;
 
            QuestList.DisplayMemberPath = "Id";
        }

        private void QuestList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new ViewPage(QuestList.SelectedItem as Question,this));
        }
    }
}
