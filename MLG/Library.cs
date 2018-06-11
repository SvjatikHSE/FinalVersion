using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MLG
{
    
    public class Package
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Question CurrentQuestion { get; set; }
        public bool IsAlreadyPlayed { get; set; }
        public int? ResultOfUser { get; set; }
        public List<Question> Questions { get; set; }

        public void LoadData(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            Name = "TestPack";
            foreach(XmlNode node in doc.DocumentElement)
            {
                string tourFileName = node["tourFileName"].InnerText;
                string question = node["Question"].InnerText;
                string comments = node["Comments"].InnerText;
                string tourTittle = node["tourTitle"].InnerText;
                string tournamentTittle = node["tournamentTitle"].InnerText;
                string author = node["Authors"].InnerText;
                string answer = node["Answer"].InnerText;
                 Question questionSmth= new Question()
                {
                    TourFileName = tourFileName,
                    FieldQuestion = question,
                    Comments = comments,
                    TourTittle = tourTittle,
                    TournamentTittle = tournamentTittle,
                    Author = author,
                    Answer=answer
                };
                if(Questions==null)
                {
                    Questions = new List<Question>();
                    Questions.Add(questionSmth);
                }
                else
                {
                    Questions.Add(questionSmth);
                }
            }

        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Answer { get; set; }
        public int SessionRating { get; set; }
        public int TotalRating { get; set; }
        public List<Session> Sessions { get; set; }
    }

    public class Session
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Package Package { get; set; }
        public int Score { get; set; }
        public string PackName { get; set; }

    }

    public class Information
    {
        public void DownloadInfo(string remoteUri,string fileName)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(remoteUri, fileName);
        }
    }

    public class Question
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public string TourFileName { get; set; }
        public string FieldQuestion { get; set; }
        public string Answer { get; set; }
        public string Author { get; set; }
        public string Comments { get; set; }
        public string TourTittle { get; set; }
        public string TournamentTittle { get; set; }
    }
    public static class UILogic
    {
        public static void CreateSession(User user, Package pack)
        {
            if (user.Sessions.Count == 0)
            {
                user.Sessions = new List<Session>();
            }
            var newSession = new Session() { User = user, Package = pack, PackName = pack.Name };
        }
        public static void AdaptPacksForUser(User user, List<Package> packs)
        {
            if (user.Sessions != null)
            {
                foreach (var pack in packs)
                {
                    if (user.Sessions.Any(x => x.PackName == pack.Name))
                        pack.IsAlreadyPlayed = true;
                }
            }
        }
    }
}
