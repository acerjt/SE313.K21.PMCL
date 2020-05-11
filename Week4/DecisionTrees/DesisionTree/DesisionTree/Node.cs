using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesisionTree
{
    class Node
    {
        public DecisionQuery partition_question;
        public List<DecisionQuery> questions;
        public List<Attribute> attributes;
        public List<Node> branch;
        public Node(DecisionQuery partition_question, List<DecisionQuery> questions, List<Attribute> attributes)
        {
            this.partition_question = partition_question;
            this.questions = questions;
            this.attributes = attributes;
        }
        public Node()
        {

        }
    }
}
