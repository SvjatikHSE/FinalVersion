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
        public string Answer { get; set; }
    }
    public class Package
    {
        public int Id { get; set; }
        public List<Question> Questions { get; set; }
        public String Name { get; set; }
    }
}
