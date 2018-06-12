using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG
{
    public class DBRepository
    {
        public List<Package> Packages { get; set; }
        public List<Question> Questions { get; set; }
        List<Package> packages=new List<Package>();
        List<Question> questions = new List<Question>();
        List<User> users=new List<User>();

        public DBRepository()
        {
            LoadData();
        }

        public void LoadData()
        {
            //ПРОСТИ ШАГАНЕ,НО ФОРМАТ ИЗМЕНИЛСЯ ХАХАХАХАХАХ

            using (var context = new BDContext())
            {
                Packages = context.Packages.Include("Questions").ToList();
                Questions = context.Questions.ToList();
            }
            //users = new List<User>() { new User() { Name="t", Password="t"} };
            //Packages = new List<Package>() { new Package()
            //{ Name="testpack", IsAlreadyPlayed=false, Questions=new List<Question>()
            //{ new Question()
            //{ Task="trynottodye", Points=10,
            //    AllAnswers = new List<Variant>()
            //    { new Variant()
            //    { Answer="1" }, new Variant(){ Answer="2"} } } } }, new Package()
            //{ Name="testpack2", IsAlreadyPlayed=true, ResultOfUser=20, Questions=new List<Question>()
            //{ new Question()
            //{ Task="trynottodye22", Points=10,
            //    AllAnswers = new List<Variant>()
            //    { new Variant()
            //    { Answer="12" }, new Variant(){ Answer="22"} } } } } };
        }

        public bool FindUser(string name, string password, out User user)
        {
            using (var c = new BDContext())
            {
                user = c.Users.Include("Sessions").FirstOrDefault(x => x.Name == name && x.Password == password);
                return user != null;
            }
        }

        public void  AddUser(User user)
        {
            using (var context = new BDContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            users.Add(user);
        }
    }
}
