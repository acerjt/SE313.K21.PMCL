using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesisionTree
{
    class DecisionQuery
    {
        public string question { get; private set; }
        public List<Answer> possibleAnswers { get;  set; }
        public DecisionQuery(string question, List<Answer> possibleAnswers)
        {
            this.question = question;
            this.possibleAnswers = possibleAnswers;
        }
    }
}
