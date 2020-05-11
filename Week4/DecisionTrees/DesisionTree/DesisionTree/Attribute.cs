using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesisionTree
{
    class Attribute
    {
        public List<string> answers { get; private set; }
        public string title { get; private set; }
        public Attribute(List<string> answers, string title)
        {
            this.answers = answers;
            this.title = title;
        }
        public Attribute copy()
        {
            List<string> ans = new List<string>();
            string title = string.Copy(this.title);
            foreach (string s in this.answers)
            {
                ans.Add(string.Copy(s));
            }
            Attribute rs = new Attribute(ans, title);
            return rs;
        }
    }
}
