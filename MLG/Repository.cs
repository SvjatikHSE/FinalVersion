using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG
{
    public class Repository
    {
        public List<Package> Packages { get; set; }
        List<Package> packages=new List<Package>();
        List<User> users=new List<User>();

        public void LoadData()
        {
            users = new List<User>() { new User() { Name="t", Password="t"} };
            Packages = new List<Package>() { new Package()
            { Name="testpack", IsAlreadyPlayed=false, Questions=new List<Question>()
            { new Question()
            { Task="trynottodye", Points=10,
                AllAnswers = new List<Variant>()
                { new Variant()
                { Answer="1" }, new Variant(){ Answer="2"} } } } }, new Package()
            { Name="testpack2", IsAlreadyPlayed=true, ResultOfUser=20, Questions=new List<Question>()
            { new Question()
            { Task="trynottodye22", Points=10,
                AllAnswers = new List<Variant>()
                { new Variant()
                { Answer="12" }, new Variant(){ Answer="22"} } } } } };
        }

        public User FindUser(User user)
        {
            if(users.Find(x=>x.Name==user.Name).Password==user.Password)
            {
                return user;
            }
            user = null;
            return user;
        }

        public User Registration(string login,string password)
        {
            User user = new User();
            if ((login!=null)&&(password!=null))
            {
                user.Name = login;
                user.Password = password;
                this.users.Add(user);
            using (var context = new BDContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                return user;
            }
                return null;
        }
    }
}
