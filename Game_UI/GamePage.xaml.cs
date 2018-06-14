using MLG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        Package _pack;
        int _time = 60;
        int _questionNum;
        System.Windows.Threading.DispatcherTimer timer;
        Session _session;
        PackPage Ppage;

        public GamePage(Package pack, int num, Session session, PackPage packpage)
        {           
            InitializeComponent();
            Ppage = packpage;
            _pack = pack;
            _pack.CurrentQuestion = pack.Questions[num - 1];
            _questionNum = num;
            QuestionBlock.Text = _pack.CurrentQuestion.FieldQuestion;
            _session = session;
            if (_pack.CurrentQuestion.PicturePath != "")
            {
                var path = "Images/" + pack.CurrentQuestion.PicturePath;
                QuestionImage.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Images/"+_pack.CurrentQuestion.PicturePath));
                ImageButton.Visibility = Visibility.Visible;
            }
        }

        private void TimerStartButton_Click(object sender, RoutedEventArgs e)
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            
        }
        private void timerTick(object sender, EventArgs e)
        {
            if (_time > 0)
            {
                if (_time < 11) { TimerBlock.Foreground = new SolidColorBrush(Colors.Red); }
                _time--;
                TimerBlock.Text = string.Format($"00:{_time}");
            }
            else {
                ShowAnswerButton.IsEnabled = true;
                timer.Stop();
                //SystemSounds.Beep.Play();

               
                media.Play();
         
                TimerStartButton.IsEnabled = false;
            }
            
            
        }

        private void ShowAnswerButton_Click(object sender, RoutedEventArgs e)
        {   if (_pack.CurrentQuestion.Comments == "")
                _pack.CurrentQuestion.Comments = "-";
            QuestionBlock.FontSize = 30;
            QuestionBlock.Text = $" Ответ: {_pack.CurrentQuestion.Answer} \r\n Комментарий: {_pack.CurrentQuestion.Comments}" ;
            WrongAnsButton.Visibility = Visibility.Visible;
            RightAnsButton.Visibility = Visibility.Visible;
        }
        private void PointButtonBehavior()
        {
            if (_questionNum != _pack.Questions.Count())
            {
                _questionNum++;
                var nextQuestionPage = new GamePage(_pack, _questionNum, _session, Ppage);
                NavigationService.Navigate(nextQuestionPage);
            }
            else
            {
                var theEndPage = new ResultPage(_session);
                NavigationService.Navigate(theEndPage);
            }
        }
        private void WrongAnsButton_Click(object sender, RoutedEventArgs e)
        {
            PointButtonBehavior();
        }

        private void RightAnsButton_Click(object sender, RoutedEventArgs e)
        {
            _session.Score++;
            PointButtonBehavior();

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Ppage);
        }
        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionImage.Visibility == Visibility.Hidden)
                QuestionImage.Visibility = Visibility.Visible;
            else
                QuestionImage.Visibility = Visibility.Hidden;
        }
    }
}
