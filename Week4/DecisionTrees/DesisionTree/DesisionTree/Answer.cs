using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesisionTree
{
    class Answer
    {
        public string answer;
        public int yes;
        public int no;
        public string ANSWER
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;

            }
        }
        public int YES
        {
            get
            {
                return yes;
            }
            set
            {
                yes = value;
            }
        }
        public int NO
        {
            get
            {
                return no;
            }
            set
            {
                no = value;
            }
        }
    }
}
