using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG
{
    class Repository
    {
        List<Package> packages=new List<Package>();
        List<User> users=new List<User>();

        public void LoadData()
        {
            users = new List<User>();
            packages = new List<Package>();
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
