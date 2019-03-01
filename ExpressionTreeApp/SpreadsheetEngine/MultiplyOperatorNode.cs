using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class MultiplyOperatorNode : BaseOperatorNode
    {
        public MultiplyOperatorNode(char c)
        {
            this.Operator = c;
            this.Left = this.Right = null;
        }

        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            return this.Left.Evaluate(ref variables) * this.Right.Evaluate(ref variables);
        }
    }
}
