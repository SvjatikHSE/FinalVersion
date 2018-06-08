using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG
{
    public class Question
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public Variant CorrectAnswer { get; set; }
        public List<Variant> AllAnswers { get; set; }
        public int Points { get; set; }


        public bool TrueAnswer(User user,Question question)
        {
            if (user.Answer == question.CorrectAnswer.Answer)
                return true;
            else
                return false;
        }
    }
    public class Package
    {
        public int Id { get; set; }
        public List<Question> Questions { get; set; }
        public String Name { get; set; }
        public Question CurrentQuestion { get; set; }
        public bool IsAlreadyPlayed { get; set; }
        public int? ResultOfUser { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Answer { get; set; }
        public int SessionRating { get; set; }
        public int TotalRating { get; set; }
    }

    public class Variant
    {
        public int Id { get; set; }
        public string Answer { get; set; }
    }

    public class Session
    {
        public User User { get; set; }
        public Package Package { get; set; }
        public bool Aegis { get; set; }
        public bool FiftyFifty { get; set; }
        public bool FriendlyCall { get; set; }

        public bool AegisAction()
        {
            if(this.Aegis==true)
            {
                CorrectAnswerAction();
                Aegis = false;
                return true;
            }
            return false;
        }

        public bool FiftyFiftyAction()
        {
            if(this.FiftyFifty==true)
            {
                Random random1 = new Random();
                int value1 = random1.Next(0, 4);
                int value2;
                do
                    value2 = random1.Next(0, 4);
                while (value1==value2);
                Package.CurrentQuestion.AllAnswers.RemoveAt(value1);
                Package.CurrentQuestion.AllAnswers.RemoveAt(value2);
                return true;
            }
            return false;
        }

        public void CorrectAnswerAction()
        {
            User.SessionRating += this.Package.CurrentQuestion.Points;
            User.TotalRating += this.Package.CurrentQuestion.Points;
            int currentQuestionNumber = this.Package.Questions.FindIndex(x=>x==Package.CurrentQuestion);
            this.Package.CurrentQuestion = this.Package.Questions[currentQuestionNumber + 1];
        }

    }
}
