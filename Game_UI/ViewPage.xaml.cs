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
            PackNameTextBlock.Text = Quest.TournamentTittle;
            if (question.PicturePath != "")
            {
                var path = "Images/" + question.PicturePath;
                QuestionImage.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Images/" + question.PicturePath));
                ImageButton.Visibility = Visibility.Visible;
            }

        }

    
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Qpage);
        }

        private void AnswButton_Click(object sender, RoutedEventArgs e)
        {
            QuestTextBlock.FontSize = 32;
            if (Quest.Comments == "")
                Quest.Comments = "-";
            QuestTextBlock.Text = $" Ответ: {Quest.Answer} \r\n Комментарий: {Quest.Comments}";
            AnswButton.IsEnabled = false;
            QuestButton.IsEnabled = true;
            
        }

        private void QuestButton_Click(object sender, RoutedEventArgs e)
        {
            QuestTextBlock.Text = Quest.FieldQuestion;
            AnswButton.IsEnabled = true;
            QuestButton.IsEnabled = false;
           
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {   if (QuestionImage.Visibility == Visibility.Hidden)
                QuestionImage.Visibility = Visibility.Visible;
            else
                QuestionImage.Visibility = Visibility.Hidden;
        }
    }
}
