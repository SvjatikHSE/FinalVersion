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
    /// Логика взаимодействия для ViewPage.xaml
    /// </summary>
    public partial class ViewPage : Page
    {
        Question Quest;
        QuestionPage Qpage;
        public ViewPage(Question question, QuestionPage questpage)
        {
            Qpage = questpage;
            Quest = question;
            InitializeComponent();
            QuestTextBlock.Text = Quest.FieldQuestion;
           
        }

    
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Qpage);
        }

        private void AnswButton_Click(object sender, RoutedEventArgs e)
        {
            QuestTextBlock.Text = Quest.Answer;
        }
    }
}
