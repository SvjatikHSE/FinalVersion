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
        PackPage Ppage;
        public QuestionPage(Package pack,PackPage packpage)
        {
            InitializeComponent();
            PackNameLabel.Content = pack.Name;
            List<Question> shortQuestions = new List<Question>();
            for(int i=0;i<pack.Questions.Count;i++)
            {
                if(pack.Questions[i].FieldQuestion.Length<=100)
                {
                    shortQuestions.Add(pack.Questions[i]);
                }
                else
                {
                    pack.Questions[i].FieldQuestion.Substring(101);
                    pack.Questions[i].FieldQuestion += "...";
                    shortQuestions.Add(pack.Questions[i]);
                }
            }
            QuestList.ItemsSource = shortQuestions;
            QuestList.DisplayMemberPath = "FieldQuestion";
            
            Ppage = packpage;
        }

    

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Ppage);
        }

        private void QuestList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ViewPage(QuestList.SelectedItem as Question, this));
        }
    }
}
